using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateplane : MonoBehaviour {

    private Rigidbody cube;
    public float amount = 50f;
	// Use this for initialization
	void Start () {
        cube = GetComponent<Rigidbody>();
        cube.maxAngularVelocity = 15;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
        float h = amount * Time.deltaTime;
        cube.AddTorque(transform.up * h);
        //transform.rotation = Quaternion.identity;
    }
}
