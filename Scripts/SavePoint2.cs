using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            {

            other.GetComponent<PlayerController>().respawnPoint = 1;
            gameObject.SetActive(false);
            }
    }
}
