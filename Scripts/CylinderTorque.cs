using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderTorque : MonoBehaviour {

    private Rigidbody cylinder;
    public float amount;
    public float amount2;
    
    // Use this for initialization
    void Start () {
        cylinder = GetComponent<Rigidbody>();
        cylinder.maxAngularVelocity = 15;
    }
	
	// Update is called once per frame
	void Update () {
        float h = amount * Time.deltaTime;
        float g = amount2 * Time.deltaTime;
        cylinder.AddTorque(transform.up * h, ForceMode.Acceleration);
        
        

    }
}
