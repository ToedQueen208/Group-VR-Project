using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_InventoryManage : MonoBehaviour {
    /*
     stores in array
     only active one is showing
     deactive all of the rest
     when one is added all of the others move down one
     only does if it is not full
         
         */




    public GameObject[] items;
  [SerializeField]  private int counter;
[SerializeField] public GameObject displayitem;
    int num;
    [SerializeField] Transform hand;

    

	// Use this for initialization
	void Start () {
        counter = 0;
      //  objectManager.GetComponent<SCR_objectManager>();
    

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            num = 0;
                currentitemonDisplay(num);
       //     objectManager.grabbedObject = items[num];

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            num = 1;

          currentitemonDisplay(num);
      //      objectManager.grabbedObject = items[num];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            num = 2;

            currentitemonDisplay(num);
    //        objectManager.grabbedObject = items[num];
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            num = 3;

            currentitemonDisplay(num);
      //      objectManager.grabbedObject = items[num];
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            num = 4;

            currentitemonDisplay(num);
        //    objectManager.grabbedObject = items[num];
        }
       
    }

     public bool checkfull()
    {
        counter = 0;

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                Debug.Log("counting");

                counter += 1;
            }     
        }
        if (counter >=5)
        {
   return true;
        }
             
   return false;
             

        //if full then return false
    }
   public void additem(GameObject grabbeditem)
    {
        bool full;
        full = checkfull();
        //code adapted from  https://unity3d.com/learn/tutorials/projects/adventure-game-tutorial/inventory
        if (full == false)
        {
            for (int i = 0; i <=items.Length ; i++)
            {
                if (items[i] == null)
                {
                    items[i] = grabbeditem;
                    currentitemonDisplay(i);
                    return;
                }                
            }
           }
    }
    public void removeitem(GameObject removeditem)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == removeditem)
            {
                items[i] = null;
            }
        }
    }
    public void currentitemonDisplay(int num)
    {
        //show item at number 1
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                if (i == num)
                {
                    displayitem = items[i];
                    displayitem.transform.position = new Vector3(displayitem.transform.position.x, displayitem.transform.position.y - 0.2f, displayitem.transform.position.z);

                    StartCoroutine(switchitem());


                    items[i].gameObject.SetActive(true);

                }
                else if (i != num && items[i] != null)
                {
                    items[i].gameObject.SetActive(false);
                }
            }

        }
    }
    IEnumerator switchitem()
    {
            

        //item starts lower than position and floats up;


        while (displayitem.transform.position != hand.transform.position)
        {
            displayitem.transform.position = Vector3.Lerp(displayitem.transform.position,hand.transform.position, 0.5f);
          
            yield return new WaitForSeconds(0.00001f);
        }


    }
}
