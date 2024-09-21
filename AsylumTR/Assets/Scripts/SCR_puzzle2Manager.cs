using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_puzzle2Manager : MonoBehaviour {
    /*
    for each correct puzzle add 1 maybe or have bool for each one
        
    */
    [SerializeField] private SCR_EndGame puzzlecounter;
    public bool[] correctpuzzles;
    [SerializeField] private AudioSource player;
    [SerializeField] private AudioClip clip;
    bool played = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (correctpuzzles[0] == true && correctpuzzles[1] == true && correctpuzzles[2] == true && correctpuzzles[3] == true && correctpuzzles[4] == true)
        {
            if (played == false)
            {
                player.PlayOneShot(clip);
                played = true;

            }

            puzzlecounter.puzzledone[1] = true;

        }
        else
            played = false;

        }
       
	}

