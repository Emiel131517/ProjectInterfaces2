using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject panel;

    private void Start()
    {
        panel = GameObject.Find("PanelBar");

        panel.SetActive(false);
    }

    public void ShowArduino()
    {
        panel.SetActive(true);
    }

    public void StartGame()
    {
        if (SerialConnect.isPortActive)
        {
            SceneManager.LoadScene("Main");
        }
    }
    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
