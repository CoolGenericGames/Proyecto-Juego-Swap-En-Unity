using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    #region Constantes
    protected const int ROJO = 0;
    protected const int AZUL = 1;
    #endregion

    #region Variables
    public float velXEnemigo;
    public float velYEnemigo;
    public float direccion;
    protected float timer;
    protected float cooldown;
    protected bool esRojo;
    #endregion

    #region GameObjects
    public GameObject BalaEnemigo;
    protected GameObject nuevabala;
    #endregion

    public Sprite[] spritesEnemigo;
    public Sprite spriteBalaAzul;
    public Sprite spriteBalaRoja;

    #region Métodos
    public void Move() {
        Debug.Log("Move Enemy");
    }

    public void Shoot()
    {
        Debug.Log("Enemy Shoot");
    }

    public void TimerToShoot() {
        timer += Time.deltaTime;
    }
    public void ResetTimer() {
        timer = 0;
    }
    #endregion
}
