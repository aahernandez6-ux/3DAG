using UnityEngine;
using System.Collections;

public class PlayerColllsions : MonoBehaviour
{
    // Door Animator
    [SerializeField] private GameObject door; // An open slot in the Inspector to drag the 

    Animator doorAnimor;
 
    //Door timer
    [Header ("Door timer")]
    private bool startDoorTimer = false;
    private float doorTimer = 0.0f;
    [SerializeField] private float doorOpenTime = 3.0f;

    // Door Sound
    [SerializeField] private AudioClip doorOpenSound;
    [SerializeField] private AudioClip doorShutSound;
    private new AudioSource audio; // will hold the AudioSource Component

    private bool doorIsOpen = false; //To determine current 

    //Battery sound
    [SerializeField] private AudioClip pickupCollectSound;

    // Spawn point
    [SerializeField] private Transform spawnPoint; 

    private bool isRespawning = false;

    // Start is colled once before the first execution of Update after the MonoBehaviour
    void Start()
    {
        
     doorAnimor = door.GetComponent<Animator>();
     audio = GetComponent <AudioSource> ();
    
    }
    
    

    // Update is called once per frame
    void Update()
    {
        //Run a door timer
        if(startDoorTimer)
        {
            doorTimer += Time.deltaTime;
        }

        //Automatically shut door after timer
        if(doorTimer >= doorOpenTime)
        {
            ShutDoor(); // This calls the custom method below

            doorTimer = 0.0f;
        }
    }

    // Collision dectection
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Check if th player hits an object with the houseDoortag
        if(hit.gameObject.CompareTag("houseDoor") && PickupCoollet.pickAmount >= 4)
        {
            OpenDoor(); // This calls the custom method below
            // print("Hit the door!");

            PickupCoollet.hud.enabled = false;
        }
        else if (hit.gameObject.CompareTag("houseDoor") && PickupCoollet.pickAmount < 4)
        {
            PickupCoollet.hud.enabled = true;

            TextHints.messsage = "This door needed power to open...";
            
            TextHints.textOn = true;
        }

        if (hit.gameObject.CompareTag("water") && !isRespawning)

        {
            isRespawning = true;

            TextHints.messsage = "Can't go there";

            TextHints.textOn = true;

            StartCoroutine(Respawn(2.0f)); // 2.0 is a 2 second delay
            Time.timeScale = 0;
        }
    }

    //Custom open door method
    private void OpenDoor()
    {
            if (!doorIsOpen)
            {
                audio. PlayOneShot(doorOpenSound);

                doorIsOpen = true;
            }

        //Set Animator parameter
        doorAnimor.SetBool("doorOpen", true);
    
        startDoorTimer = true;
    }

    //Costom shut door method
    private void ShutDoor()
    {
        if (doorIsOpen)
        {
            audio. PlayOneShot(doorShutSound);

            doorIsOpen = false;
        }
        

        //Set Animetor parameter
        doorAnimor.SetBool("doorOpen", false);
    }

    //Pickup collision 
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("pickup"))
        {
            PickupCoollet.pickAmount++;

            audio.PlayOneShot(pickupCollectSound);

            Destroy(coll.gameObject);
        }
    }
     
    private IEnumerator Respawn(float delay)

    {
        yield return new WaitForSecondsRealtime(delay);

        transform.position = spawnPoint.position;

        isRespawning = false;

        Time.timeScale = 1;

    }

}

