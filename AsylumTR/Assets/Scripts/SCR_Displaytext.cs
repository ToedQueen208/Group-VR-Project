using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SCR_Displaytext : MonoBehaviour {

    [SerializeField] private Text displayText;
    bool starttime;
    float timer;
    // Use this for initialization
    void Start () {
        starttime = false;
        displayText.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (starttime == true)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer >= 5)
            {
                displayText.enabled = false;
                timer = 0;
                starttime = false;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            displayText.enabled = true;
            starttime = true;

        }
    }
}
