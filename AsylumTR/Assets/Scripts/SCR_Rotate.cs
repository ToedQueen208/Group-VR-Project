using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Rotate : MonoBehaviour {
    [SerializeField] public bool rott;
    [SerializeField] private GameObject rotateobj;
    [SerializeField] private Rigidbody player;
    [SerializeField] float rotspeed;
    // Use this for initialization
    void Start () {
        rott = false;
	}
	
	// Update is called once per frame
	void Update () {
      
      
       
	}
 
    IEnumerator rot(bool rotated)
    {
       
        if (rotated == false)
        {
            float x = 0;
            while (x < 181)
            {
                x += rotspeed * Time.deltaTime;
                rotateobj.transform.rotation = Quaternion.Euler(x, 0, 0);
       
                player.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
                player.GetComponent<Rigidbody>().useGravity = false;
                yield return new WaitForSeconds(0.00001f);
            }
            rott = true;
            player.constraints = RigidbodyConstraints.None;
            player.GetComponent<Rigidbody>().useGravity = true;
            yield return null;

        }
        if (rotated == true)
        {
float x = 179;
            while (x > 0)
            {
                x -= rotspeed * Time.deltaTime;
                rotateobj.transform.rotation = Quaternion.Euler(x, 0, 0);

                player.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
                player.GetComponent<Rigidbody>().useGravity = false;
                yield return new WaitForSeconds(0.01f);
            }
            rott = false;
            player.constraints = RigidbodyConstraints.None;
            player.GetComponent<Rigidbody>().useGravity = true;
            yield return null;
        }



    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)) 
        {

            if (rott == false)
            {
                StartCoroutine(rot(false));

            }
            else if (rott == true)
            {
                StartCoroutine(rot(true));
            }

        }
    }
}
