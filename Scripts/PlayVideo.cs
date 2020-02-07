using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayVideo : MonoBehaviour {

    public GameObject videoPlayer;
    public Text winText;
    private bool timerActive;
    public float startTime;
    private float targetTime;

	// Use this for initialization
	void Start () {
        videoPlayer.SetActive(false);
        //winText.text = "";
        targetTime = 26.0f;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            
            videoPlayer.SetActive(true);
            timerActive = true;
            startTime = 0f;

            player.GetComponent<PlayerController>().speed = 3;

            //videoPlayer.SetActive(false);
            //winText.text = "Plöpp";
            
        }
    }
    void Update()
    {
        if (timerActive)
        {
            startTime += Time.deltaTime;
            if (startTime > targetTime)
            {
                videoPlayer.SetActive(false);
                timerActive = false;
                startTime = 0.0f;
            }

        }
    }
}
