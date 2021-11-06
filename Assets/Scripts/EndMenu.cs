﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void Resart()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
