using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static int Score;
    public string ScoreString = "Score";


    public Text TextScore;

    public static GameController gameController;

    void Awake()
    {
        gameController = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if(TextScore != null)
        {
            TextScore.text = ScoreString + Score.ToString ();
        }
    }
}
