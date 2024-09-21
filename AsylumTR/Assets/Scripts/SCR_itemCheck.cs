using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_itemCheck : MonoBehaviour {
    /*
     each place checks for an item on there (check child)
     if correct then either add to a value or create a bool for each place
     if taken off then deduct point or set bool to false
     each script is on each place
     have a puzzle 2 manager script

         */
    public string itemName;
    GameObject child;
    public int puzzlenum;

    public SCR_puzzle2Manager puzzzle2script;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.transform.childCount == 2)
        {
            child = this.gameObject.transform.GetChild(1).gameObject;
            if (child.gameObject.name == itemName)
            {
                                
                puzzzle2script.correctpuzzles[puzzlenum] = true;
                
                   }


        }
        else
        {
            puzzzle2script.correctpuzzles[puzzlenum] = false;
            //tell there is nothing
        }
	}
}
