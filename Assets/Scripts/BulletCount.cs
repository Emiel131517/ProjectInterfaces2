using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCount : MonoBehaviour
{
    private Text bulletCount;
    private Player plane;

    void Start()
    {
        bulletCount = GetComponent<Text>();
        plane = GameObject.FindGameObjectWithTag("Plane").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletCount.text = "Bullets:" + plane.bullets;
    }
}
