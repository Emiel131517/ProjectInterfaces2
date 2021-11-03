using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathText : MonoBehaviour
{
    private Text deathText;
    private Highscore highScore;
    private Player plane;
    void Start()
    {
        deathText = GetComponent<Text>();
        highScore = GameObject.Find("ScoreText").GetComponent<Highscore>();
        plane = GameObject.FindGameObjectWithTag("Plane").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (plane.playerIsAlive == false)
        {
            deathText.text = "Oh no, you crahed!\nYour score is: " + Mathf.Round(highScore.score);
        }
    }
}
