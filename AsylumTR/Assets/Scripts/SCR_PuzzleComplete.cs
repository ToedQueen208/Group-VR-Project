    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SCR_PuzzleComplete : MonoBehaviour {
//
  //  [SerializeField] private Text finishText;
    bool starttime;
    float timer;
  [HideInInspector]  public bool bUnlockDoors;
    [SerializeField] private GameObject tiles;
    [SerializeField] private SCR_EndGame puzzlecounter;
    bool completed;


    // Use this for initialization
    void Start () {
        bUnlockDoors = false;
        completed = false;

    
    }
	
	// Update is called once per frame
	void Update () {
        if (completed == true)
        {
            tiles.gameObject.SetActive(false);
        }
       
	}

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Key"))
        {
         
            bUnlockDoors = true;
            puzzlecounter.puzzledone[0] = true;

            StartCoroutine("dissapear");
            Destroy(other.gameObject);
         
           


        }
        
    }

    IEnumerator dissapear()
    {
        //make them dissapear by making them move undergroound
        //have some particle effects maybe???
        while (completed == false)
        {
            tiles.transform.Translate(0, -0.01f, 0);
            yield return new WaitForSeconds(0.001f);
            if (tiles.transform.position.y <= -1)
            {
                completed = true;
                yield return null; 
            }
        }

      

    }
}
