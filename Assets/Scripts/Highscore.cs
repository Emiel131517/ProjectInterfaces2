using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    private Text scoreText;
    public static float score = 0;
    private float scoreAddPerSec = 5;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.playerIsAlive == true)
        {
            score += scoreAddPerSec * Time.deltaTime;
            scoreText.text = "Score: " + Mathf.Round(score);
        }
    }
}
