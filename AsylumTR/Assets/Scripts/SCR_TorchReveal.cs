using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_TorchReveal : MonoBehaviour
{

    public GameObject torch;
    public Collider revealer;

    public Light torchLight;
    bool BisLightOn;
    private Ray ray;
    RaycastHit hit;
    int layerMask;

    private Renderer rend;
    private float counter;


    // Use this for initialization
    void Start()
    {

        layerMask = 1 << 10;

        BisLightOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && BisLightOn == false)
        {
            BisLightOn = true;

        }
        else if (Input.GetKeyDown(KeyCode.T) && BisLightOn == true)
        {
            BisLightOn = false;

        }
        revealer.enabled = BisLightOn;
        torchLight.enabled = BisLightOn;
        //use raycasts to detect objects
        //if hovered over them then they are set active
              
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
  /*      if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask) && hit.collider.gameObject.tag == "txt")

        {
            counter = 0;
            rend = hit.collider.gameObject.GetComponent<Renderer>();
//call fade script on objects
         //               Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
     //       Debug.Log("Did Hit");
        }
        else
        {
            counter += 1 * Time.deltaTime;
                 
       //     Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);


            if (counter >= 1)
            {

            }

        }
        */
    }
 
}

