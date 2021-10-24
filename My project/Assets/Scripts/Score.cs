using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public int score;
    public int highscore;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI highscoreUI;


    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore");
    }
    private void Update()
    {
        scoreUI.text = score.ToString();
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
        highscoreUI.text = highscore.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider is working");
        if (other.gameObject.tag == "scoreup")
        {
            score++;
        }
    }
}
