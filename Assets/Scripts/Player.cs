using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    private int bullets = 15;
    private int score = 0;

    private Camera playerCam;
    public Transform playerModel;
    public Transform target;

    void Start()
    {
        playerCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Movement();
        StrafeH(playerModel, h);
        //RotateUpDown(playerModel, v);
    }

    public void Movement()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.up * -speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * -speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
    }

    public void StrafeH(Transform player, float axisH)
    {
        Vector3 eulerAngles = player.localEulerAngles;
        player.localEulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, Mathf.LerpAngle(eulerAngles.z, axisH * 25, 0.25f));
    }

    public void RotateUpDown(Transform player, float axisV)
    {
        Vector3 eulerAngles = player.localEulerAngles;
        player.localEulerAngles = new Vector3(Mathf.LerpAngle(eulerAngles.x, -axisV * 25, 0.25f), eulerAngles.y, eulerAngles.z);
    }

    void LateUpdate()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
