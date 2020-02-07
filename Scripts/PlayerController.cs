using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject NorthWall;
    //public GameObject PlayerBall;
    public float speed;
    private Rigidbody rb;
    private int count;
    private Rigidbody rb2;
    private Rigidbody rb3;
    public Text countText;
    public Text winText;
    public AudioClip triggerSound;
    public AudioClip snakeDeath;
    public AudioClip temmiebark;
    public Vector3[] positionTransformList;
    public Vector3[] magicCylinderPositionTransformlist;
    private GameObject[] cylinderObjects;
    private GameObject[] magicCylinderObjects;
    private int positionTransformListCounter;
    private int magicCylinderPositionTransformlistCounter;
    public int respawnPoint;

    AudioSource audioSource;
    //private int videoPlayed;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        positionTransformListCounter = 0;
        magicCylinderPositionTransformlistCounter = 0;
        respawnPoint = 0;
        rb = GetComponent<Rigidbody>();
        count = 0;
        
        

        SetCountText();
        winText.text = "";

        //Hämta och spara alla 2nd platform objektpositioner, som sedan kan återställas on death.
        cylinderObjects = GameObject.FindGameObjectsWithTag("2ndplatformcylinder");
        positionTransformList = new Vector3[cylinderObjects.Length];
        magicCylinderObjects = GameObject.FindGameObjectsWithTag("MagicCylinder");
        magicCylinderPositionTransformlist = new Vector3[magicCylinderObjects.Length];
        //nprivate Transform[] potitionList;

        foreach (GameObject i in cylinderObjects)
        {
            
            positionTransformList[positionTransformListCounter] = i.transform.position;
            positionTransformListCounter++;
        }

        foreach(GameObject i in magicCylinderObjects)
        {
            magicCylinderPositionTransformlist[magicCylinderPositionTransformlistCounter] = i.transform.position;
            magicCylinderPositionTransformlistCounter++;
        }

    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        //vp.playbackSpeed = vp.playbackSpeed / 10.0F;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        var vp = GetComponent<UnityEngine.Video.VideoPlayer>();

        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            //countText.text = "Count: " + count.ToString();
            SetCountText();
            audioSource.PlayOneShot(triggerSound, 0.5F);
            if(count >= 11)
            {
                winText.text = "You win!";
                NorthWall.transform.position += new Vector3(20, 0, 0);
                
            }

        }
        if (other.gameObject.CompareTag("PlaneSpec"))
        {
            rb.AddForce(Vector3.up * 10, ForceMode.VelocityChange);
            audioSource.PlayOneShot(temmiebark, 0.5F);
            //rb.AddForce(Vector3.forward * 300);
        }
        if (other.gameObject.CompareTag("2ndplatformtemmie"))
        {
            rb.AddForce(Vector3.up * 10, ForceMode.VelocityChange);
            audioSource.PlayOneShot(temmiebark, 0.5F);
            //rb.AddForce(Vector3.forward * 300);
        }
        if (other.gameObject.CompareTag("DeathGround"))
        {
            audioSource.PlayOneShot(snakeDeath, 0.5F);
            if(respawnPoint == 0)
            {
                rb.transform.position = new Vector3(0, 2, 0);
            }
            if(respawnPoint == 1)
            {
                rb.transform.position = new Vector3(-30, -1, 187);
            }
            speed = 5;
            rb.velocity = new Vector3(0, 0, 0);
            rb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            rb.freezeRotation = true;
            rb.freezeRotation = false;
            //Stänger av videoplayer
            GameObject vpMeme = GameObject.FindGameObjectWithTag("VPmeme");
            if(vpMeme != null)
            {
                vpMeme.SetActive(false);
            }
            //Återställer temmieplatta
            GameObject scooba = GameObject.FindGameObjectWithTag("2ndplatformtemmie");
            scooba.transform.position = new Vector3(0, 0, 67);
            scooba.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            rb3 = scooba.GetComponent<Rigidbody>();
            rb3.velocity = new Vector3(0, 0, 0);
            rb3.freezeRotation = true;
            rb3.freezeRotation = false;

            //Återställer 2nd platform cylindrar
            positionTransformListCounter = 0;
            foreach (GameObject i in cylinderObjects)
            {
                GameObject ploopa = cylinderObjects[positionTransformListCounter];
                rb2 = ploopa.GetComponent<Rigidbody>();
                rb2.velocity = new Vector3(0, 0, 0);
                rb2.freezeRotation = true;
                rb2.freezeRotation = false;
                ploopa.transform.position = positionTransformList[positionTransformListCounter];
                ploopa.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                positionTransformListCounter++;
            }

            //Återställer magiccylindrar
            magicCylinderPositionTransformlistCounter = 0;
            foreach(GameObject i in magicCylinderObjects)
            {
                GameObject ploopa = magicCylinderObjects[magicCylinderPositionTransformlistCounter];
                rb2 = ploopa.GetComponent<Rigidbody>();
                rb2.velocity = new Vector3(0, 0, 0);
                rb2.freezeRotation = true;
                rb2.freezeRotation = false;
                ploopa.transform.position = magicCylinderPositionTransformlist[magicCylinderPositionTransformlistCounter];
                ploopa.transform.rotation = Quaternion.Euler(new Vector3(77, 0, 0));
                magicCylinderPositionTransformlistCounter++;
            }

            

        }
        

        if (other.gameObject.CompareTag("SecondBounce"))
        {
            rb.AddForce(Vector3.up * 20, ForceMode.VelocityChange);
        }

    }

    void ShowScamazDonation()
    {

    }

    

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
