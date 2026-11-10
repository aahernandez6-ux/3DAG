using UnityEngine;

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
        if(hit.gameObject.CompareTag("houseDoor"))
        {
            OpenDoor(); // This calls the custom method below
            print("Hit the door!");
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
}
