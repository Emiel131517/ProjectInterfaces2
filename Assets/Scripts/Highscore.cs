using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    private Text scoreText;
    public float score = 0;
    private float scoreAddPerSec = 5;
    private Player plane;

    void Start()
    {
        scoreText = GetComponent<Text>();
        plane = GameObject.FindGameObjectWithTag("Plane").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (plane.playerIsAlive == true)
        {
            score += scoreAddPerSec * Time.deltaTime;
            scoreText.text = "Score: " + Mathf.Round(score);
        }
    }
}
