using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int bullets = 15;
    public static bool playerIsAlive = true;

    [SerializeField] GameObject objectWithSerialConnect;
    private SerialConnect myScript;
    [SerializeField]
    //private GameObject myBehaviorObject;
    private List<int> actValues;

    private float rollAngle;
    private float yawAngle;
    private float velocity = 0.001f;
    void Start()
    {
        myScript = objectWithSerialConnect.GetComponent<SerialConnect>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Movement()
    {
        actValues = myScript.values;

        if (actValues.Count >= 4)
        { 
            Quaternion newRot = new Quaternion(actValues[0], -actValues[2], actValues[1], actValues[3]);
            this.transform.rotation = this.transform.parent.rotation * Quaternion.Euler(new Vector3(-newRot.eulerAngles.x, 0, -newRot.eulerAngles.z));
            rollAngle = newRot.eulerAngles.z;
            if (rollAngle >= 180)
            {
                rollAngle = rollAngle - 360;
            }
            if (rollAngle >= 90)
            {
                rollAngle = 90;
            }
            if (rollAngle < -90)
            {
                rollAngle = -90;
            }
            transform.Translate(Vector3.right * rollAngle * velocity, Camera.main.transform);

            yawAngle = newRot.eulerAngles.x;
            if (yawAngle >= 180)
            {
                yawAngle = yawAngle - 360;
            }
            if (yawAngle >= 90)
            {
                yawAngle = 90;
            }
            if (yawAngle < -90)
            {
                yawAngle = -90;
            }
            transform.Translate(Vector3.up * yawAngle * velocity, Camera.main.transform);
        }
    }

    public void Shoot()
    {
        if (bullets > 0)
        {
            bullets--;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 20))
            {
                if (hit.transform.CompareTag("Destructable"))
                {
                    Destroy(hit.transform.gameObject);
                    Highscore.score += 10;
                }
            }
        }
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
        playerIsAlive = false;
        SceneManager.LoadScene("End Menu");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullets"))
        {
            bullets += 5;
            PickupAnimation.pickupSound.Play();
            Destroy(other.gameObject);
        }
    }
}
