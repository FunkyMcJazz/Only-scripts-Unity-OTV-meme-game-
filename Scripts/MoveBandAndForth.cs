using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBandAndForth : MonoBehaviour {
    public Vector3 startPosition;
    public Vector3 endPosition;
    public Vector3 speed = new Vector3(1, 0, 0);
    public Vector3 speedBack = new Vector3(-1, 0, 0);
    bool flag;
	// Use this for initialization
	void Start () {
        startPosition = transform.position += new Vector3(2, 0, 0);
        endPosition = transform.position += new Vector3(-13, 0, 0);
        flag = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if(Vector3.Distance(transform.position, endPosition) < 1.0f)
        {
            flag = true;
        }
        if(Vector3.Distance(transform.position, startPosition) < 1.0f)
        {
            flag = false;
        }
        if(flag == true)
        {
            transform.position += speed * (Time.deltaTime * 2);
        }
        else
        {
            transform.position += speedBack * (Time.deltaTime * 2);
        }
            

        
	}
}
