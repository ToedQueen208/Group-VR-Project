using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlaySound : MonoBehaviour {
   [SerializeField] private AudioClip sound;
  [SerializeField]  private AudioSource player;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            if (player.isPlaying)
            {
                         
            }
            else
            {
                player.PlayOneShot(sound);
            }
         
            Destroy(gameObject);
        }
       

    }

}
