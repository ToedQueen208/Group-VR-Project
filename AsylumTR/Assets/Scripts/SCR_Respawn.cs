using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SCR_Respawn : MonoBehaviour {
    [SerializeField] private Transform spawnpoint;
  [SerializeField] private  GameObject player;
    [SerializeField] private Canvas spawncanvas;
    [SerializeField] CharacterController cc;
    [SerializeField] private Image fadeimage;
    private bool isShowing = true;

	// Use this for initialization
	void Start () {
       cc = GetComponent<CharacterController>();
        fadeimage.enabled = false;
      //  spawncanvas.enabled = false;
       
    }
	
	// Update is called once per frame
	void Update () {
        if (isShowing == false)
        {
            cc.enabled = false;
        }
        else
        {
            cc.enabled = true;
        
          
           
        }
	}
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Respawn"))
        {
            spawncanvas.enabled = true;
            fadeimage.enabled = true;

         isShowing = false;
            StartCoroutine(fade());

           

         


        }
    }
 IEnumerator fade()
    {
        for (float f = 0; f <1.1; f+=0.1f)
        {
            Color c = fadeimage.material.color;
            c.a = f;
            fadeimage.material.color= c;
            yield return new WaitForSeconds(0.01f);
        }
        player.transform.position = spawnpoint.position;
        yield return new WaitForSeconds(0.02f);
       
        for (float f = 1; f > 0; f -= 0.1f)
        {
            Color c = fadeimage.material.color;
            c.a = f;
            fadeimage.material.color = c;
            yield return new WaitForSeconds(0.02f);
        }
     
        isShowing = true;
        fadeimage.enabled = false;
        yield return null;
    }

    }

