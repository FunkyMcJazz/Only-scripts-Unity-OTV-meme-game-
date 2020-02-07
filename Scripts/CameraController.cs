using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    public Vector3 pos1, pos2, pos3, pos4, currentPos;
    private int rotationHitCount;
    Vector3[] cameraAngleArray = new[] { new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1f) };

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
        cameraAngleArray[0] = transform.position - player.transform.position;
        //cameraAngleArray[1] = transform.position 
        rotationHitCount = 0;
        
        pos1 = new Vector3(0, 7, -10);
        pos2 = new Vector3(10, 7, 0);
        pos3 = new Vector3(0, 7, 10);
        pos4 = new Vector3(-10, 7, 0);
        currentPos = pos1;
       
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            if(rotationHitCount == 4)
            {
                rotationHitCount = 0;
            }
            if(rotationHitCount == 0)
            {
                currentPos = pos2;
            }
            if (rotationHitCount == 1)
            {
                currentPos = pos3;
            }
            if (rotationHitCount == 2)
            {
                currentPos = pos4;
            }
            if (rotationHitCount == 3)
            {
                currentPos = pos1;
            }
            transform.Rotate(0, -90, 0, Space.World);
            
            rotationHitCount += 1;

        }
        else
        {
            transform.position = player.transform.position + currentPos;

        }
    }
}
