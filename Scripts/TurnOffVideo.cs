using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffVideo : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip success;

    // Use this for initialization
    void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameObject vpMeme = GameObject.FindGameObjectWithTag("VPmeme");
            vpMeme.SetActive(false);
            audioSource = other.GetComponent<AudioSource>();
            audioSource.PlayOneShot(success, 0.5f);

            other.GetComponent<PlayerController>().speed = 5;
        }
    }
    // Update is called once per frame
    void Update ()
    {
		
	}

}
