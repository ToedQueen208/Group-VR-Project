using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_LoadScene : MonoBehaviour {
    [SerializeField] private string sceneName;
    [HideInInspector] public int puzzlecomplete;



	// Use this for initialization
	void Start () {
        puzzlecomplete = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && puzzlecomplete ==1)
        {
            SceneManager.LoadScene(sceneName);

        }
    }

}
