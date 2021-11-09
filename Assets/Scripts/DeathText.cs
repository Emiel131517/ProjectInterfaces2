using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathText : MonoBehaviour
{
    private Text deathText;
    void Start()
    {
        deathText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.playerIsAlive == false)
        {
            deathText.text = "Oh no, you crashed!\nYour score is: " + Mathf.Round(Player.score);
        }
    }
}
