using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoNave : MonoBehaviour
{
    #region Variables

    public int limiteDeBalas;

    public float velocidad;
    private float xSize;
    private float ySize;
    private float navexSize;
    private float naveySize;
    private int vidas;
    private float invencible;

    private bool esRoja;

    #endregion

    #region Componentes

    public Text perdiste;

    private Camera cam;

    private Vector3 moverX;
    private Vector3 moverY;

    private Collider2D naveCollider;

    public GameObject Bala;
    private GameObject nuevabala;

    public Sprite[] spritesNave;
    public Sprite spriteBalaRoja;
    public Sprite spriteBalaAzul;

    Color colorParaAlfa;

    public Text numeroVida;

    [Header("UI Texts")] // -------------------------------------------

    /// <summary>
    /// Represents the text field where the player's name will be displayed.
    /// </summary>
    public Text PlayerDisplayNameText;

    #endregion

    #region métodos de Unity
    // Start is called before the first frame update
    void Start()
    {
        colorParaAlfa = gameObject.GetComponent<SpriteRenderer>().color;
        esRoja = true;
        vidas = 3;
        naveCollider = GetComponent<Collider2D>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        ySize = cam.orthographicSize;
        xSize = ySize * cam.aspect;
        navexSize = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        naveySize = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        velocidad = 8f;
        moverX = new Vector3(1f, 0, 0);
        moverY = new Vector3(0, 1f, 0);
        invencible = 0f;


        if(PlayFabPlayerData.Get) PlayerDisplayNameText.text = PlayFabPlayerData.Get.DisplayName;
    }

    

    // Update is called once per frame
    void Update()
    {

        if (vidas <= 0)
        {
            vidas = 0;
            perdiste.gameObject.SetActive(true);
            Destroy(gameObject);
        }
        numeroVida.text = vidas.ToString();

        if (Input.GetKey(KeyCode.W) && (transform.position.y + naveySize < ySize)) transform.position += moverY * velocidad * Time.deltaTime;

        else if (Input.GetKey(KeyCode.S) && (transform.position.y - naveySize > -ySize)) transform.position -= moverY * velocidad * Time.deltaTime;

        if (Input.GetKey(KeyCode.D) && (transform.position.x + navexSize < xSize)) transform.position += moverX * velocidad * Time.deltaTime;

        else if (Input.GetKey(KeyCode.A) && (transform.position.x - naveySize > -xSize)) transform.position -= moverX * velocidad * Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.P))
        {
            DispararBala();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (esRoja)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = spritesNave[0];
                esRoja = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = spritesNave[1];
                esRoja = true;
            }
        }


        // Invencibilidad--------------------------------------------------------------

        Invencibilidad();

    }

    #endregion

    void Invencibilidad() {
        if (!naveCollider.enabled)
        {
            invencible += Time.deltaTime;
            colorParaAlfa.a = 0.2f;
            gameObject.GetComponent<SpriteRenderer>().color = colorParaAlfa;

            if (invencible > 2)
            {
                colorParaAlfa.a = 1f;
                gameObject.GetComponent<SpriteRenderer>().color = colorParaAlfa;
                naveCollider.enabled = true;
                invencible = 0f;
            }
        }
    }

    void DispararBala()
    {        
        nuevabala = ObjectsRepository.UseRepository("Bullet", new Vector2(transform.position.x, transform.position.y + naveySize), Quaternion.identity) as GameObject;
        if (!esRoja) nuevabala.GetComponent<SpriteRenderer>().sprite = spriteBalaAzul;
        else nuevabala.GetComponent<SpriteRenderer>().sprite = spriteBalaRoja;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(vidas<=0)vidas = 0;
        if (collision.CompareTag("BalaEnemigo"))
        {
           if (collision.gameObject.GetComponent<BalaEnemigo>() != null)
            {
                if (collision.gameObject.GetComponent<BalaEnemigo>().esRoja && !esRoja)
                {
                    ObjectsRepository.BackToRepository(collision.gameObject);             
                    naveCollider.enabled = false;
                    vidas--;
                }
                else if (!collision.gameObject.GetComponent<BalaEnemigo>().esRoja && esRoja)
                {
                    ObjectsRepository.BackToRepository(collision.gameObject);
                    naveCollider.enabled = false;
                    vidas--;
                }
            }
            else {
                if (collision.gameObject.GetComponent<BalaEnemigoEspecial>().esRoja && !esRoja)
                {
                    ObjectsRepository.BackToRepository(collision.gameObject);              
                    naveCollider.enabled = false;
                    vidas--;
                }
                else if (!collision.gameObject.GetComponent<BalaEnemigoEspecial>().esRoja && esRoja)
                {
                    ObjectsRepository.BackToRepository(collision.gameObject);
                    naveCollider.enabled = false;
                    vidas--;
                }
            }
        }

        if (collision.CompareTag("Enemigo"))
        {
            ObjectsRepository.BackToRepository(collision.gameObject);
            naveCollider.enabled = false;
            vidas--;
        }

		if (collision.CompareTag("EnemigoC"))
        {
            ObjectsRepository.BackToRepository(collision.gameObject);
            naveCollider.enabled = false;
            vidas--;
        }
    }

}
