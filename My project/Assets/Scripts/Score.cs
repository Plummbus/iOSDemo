using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public int score;
    public TextMeshProUGUI scoreUI;

    private void Update()
    {
        scoreUI.text = score.ToString();
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
