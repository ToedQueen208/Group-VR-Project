using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_objectGrab : MonoBehaviour {

    /*
     placed on each moveable and grabable object
     on mousedown the object is moveable AS LONG NOT GRABBED OR PLACED
     when in trigger object can be picked up, when E object picked up and placed inside inventory array
     when in trigger for placing  when F is pressed place in box 

     */

    [SerializeField] Transform guide;
    [SerializeField] Transform hand;

    [SerializeField] private SCR_InventoryManage inventory;
    private GameObject currobj;

    [SerializeField]bool isgrabbed;
   [SerializeField] bool isplaced;
    [SerializeField] bool ismoving;

    bool movable;
    [SerializeField] float distance;
  [SerializeField]  bool ispressedE;
    // Use this for initializationss
    void Start() {
        currobj = this.gameObject;
        ispressedE = false;
        isgrabbed = false;
    }

    // Update is called once per frame
    void Update() {
        distance = Vector3.Distance(gameObject.transform.position, guide.transform.position);
  
        if (ismoving == true && distance >= 0.2f)
        {
            currobj.transform.position = Vector3.Lerp(gameObject.transform.position, guide.transform.position,0.5f);
            currobj.transform.rotation = guide.transform.rotation;
            currobj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && ismoving == false && ispressedE == false && isgrabbed == false)
        {
            ispressedE = true;
            currobj.GetComponent<Rigidbody>().useGravity = false;
            currobj.GetComponent<Rigidbody>().isKinematic = true;
            currobj.GetComponent<Rigidbody>().detectCollisions = true;
            currobj.transform.position = hand.transform.position;
            currobj.transform.rotation = hand.transform.rotation;
            currobj.transform.parent = hand.transform;
            isgrabbed = true;
            isplaced = false;
            inventory.additem(currobj);

        }
        if (Input.GetKeyUp(KeyCode.E))
         {
            ispressedE = false;
        }


        if (other.gameObject.CompareTag("Place") && Input.GetKeyDown(KeyCode.F) && ismoving == false && ispressedE == false && isgrabbed == true)
        {
            if (other.transform.childCount == 1)
            {
                Transform child;
                child = other.transform.GetChild(0);
                currobj.GetComponent<Rigidbody>().useGravity = true;
                currobj.GetComponent<Rigidbody>().isKinematic = false;
                currobj.GetComponent<Rigidbody>().detectCollisions = true;
                currobj.transform.position = child.transform.position;
                currobj.transform.rotation = child.transform.rotation;
                currobj.transform.parent = other.transform;
                isplaced = true;
                isgrabbed = false;
                inventory.removeitem(currobj);
            }


        }

    }

     void OnMouseDown()
    {
        //code adapted from https://www.youtube.com/watch?v=JtflOvhOO1Y
        if (distance < 1 && isgrabbed == false && isplaced == false )
        {
 currobj.GetComponent<Rigidbody>().useGravity = false;
            currobj.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        currobj.GetComponent<Rigidbody>().isKinematic = false;
      //  currobj.GetComponent<Rigidbody>().detectCollisions = true;
        currobj.transform.position = guide.transform.position;
        currobj.transform.rotation = guide.transform.rotation;
        currobj.transform.parent = guide.transform;
            ismoving = true;

        }
       

    }
    private void OnMouseUp()
    {
        ismoving = false;
        currobj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        currobj.GetComponent<Rigidbody>().useGravity = true;

  
        currobj.transform.parent = null;

        //end of adapted code
    }
}
