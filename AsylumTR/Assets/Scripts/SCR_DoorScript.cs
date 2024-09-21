using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_DoorScript : MonoBehaviour {

    Animator ani;

    bool DoorRange = false;
    bool DoorOpened = false;
   

    // Use this for initialization
    void Start () {

        ani = GetComponent<Animator>();
		
	}
	
	
	void FixedUpdate () {

        if(DoorRange == true && DoorOpened == false)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                ani.SetTrigger("OpenDoor");

                DoorOpened = true;

            }

        }
 

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            DoorRange = true;


        }

    }

    void PauseDoor()
    {

            ani.enabled = false;

    }

    private void OnTriggerExit(Collider other)
    {

        DoorRange = false;

        if (other.tag == "Player")
        {

            ani.enabled = true;


        }
        DoorOpened = false;

    }




}
