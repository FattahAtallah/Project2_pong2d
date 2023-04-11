using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManajeo : MonoBehaviour
{
    public int ScoreL = 0;
    public int ScoreR = 0;

    //Buat UI Text
    public TMP_Text TXTScoreL;
    public TMP_Text TXTScoreR;

    public static GameManajeo instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //Mengisikan nilai integer PlayerScore ke UI
        TXTScoreL.text = ScoreL.ToString();
        TXTScoreR.text = ScoreR.ToString();
    }


    //Method penyeleksi untuk menambah score
    public void Score(string Sidewall)
    {
        if (Sidewall == "GoalL")
        {
            ScoreL++; //Menambah score
            TXTScoreL.text = ScoreL.ToString(); //Mengisikan nilai integer PlayerScore ke UI
        }
        else if (Sidewall == "GoalR")
        {
            ScoreR++;
            TXTScoreR.text = ScoreR.ToString();
        }
    }
    

    public void ScoreCheck()
    {
        if (ScoreL == 5)
        {
            Debug.Log("Playa win");
            this.gameObject.SendMessage("ChangeScene", "MainMenu");
        }
        else if (ScoreR == 5)
        {
            Debug.Log("EnemyAI win");
            this.gameObject.SendMessage("ChangeScene", "MainMenu");
        }
    }
}
public class GoalPost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (gameObject.name == "GoalR")
            {
                GameManajeo.instance.Score("GoalR");
            }
            else if (gameObject.name == "GoalL")
            {
                GameManajeo.instance.Score("GoalL");
            }
        }
    }
}