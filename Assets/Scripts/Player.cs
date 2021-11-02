using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int bullets = 15;
    private int score = 0;

    public Transform playerModel;
    public Transform target;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
        //RotateUpDown(playerModel, v);
    }

    public void Movement()
    {
        
    }

    public void Shoot()
    {
        if (bullets > 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 20))
            {
                if (hit.transform.CompareTag("Destructable"))
                {
                    Destroy(hit.transform.gameObject);
                    bullets--;
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
    }
}
