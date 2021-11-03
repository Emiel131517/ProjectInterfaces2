using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;   // for the GUI

public class RotateCube : MonoBehaviour {

    [SerializeField] GameObject objectWithSerialConnect;        // the object to which the SerialConnect script is attached

    // what to send to the Arduino when you press the action Button
    private SerialConnect myScript;
 
    // to receive values from the Arduino
    private List<int> actValues;

    private float rollAngle;
    private float yawAngle;
    private float velocity = 0.001f;

    private Quaternion origRot;

    // Use this for initialization
    void Start () {
        myScript = objectWithSerialConnect.GetComponent<SerialConnect>();
        origRot = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        // get values from Arduino
        actValues = myScript.values;
         
        if (actValues.Count >= 4)
        { // (In this case) if a valid measurement
            Quaternion newRot = new Quaternion(actValues[0], -actValues[2], actValues[1], actValues[3]);    // Gidi: since MPU9150 is righthanded and Unity left-handed
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
}
