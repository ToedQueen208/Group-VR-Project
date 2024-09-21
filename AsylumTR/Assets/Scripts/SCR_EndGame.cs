using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SCR_EndGame : MonoBehaviour {

    public bool[] puzzledone;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && puzzledone[0] == true && puzzledone[1] == true && puzzledone[2] == true)
        {
            SceneManager.LoadScene("AsylumRepaired");
        }
    }
}
