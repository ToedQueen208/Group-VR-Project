using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_FadeObject : MonoBehaviour {
  [SerializeField] bool revealed;
 [SerializeField] private Renderer rend;
    [SerializeField] private bool canBeRevealed;

    // Use this for initialization
    void Start() {
        rend = GetComponent<Renderer>();
        revealed = false;
    }

    // Update is called once per frame
    void Update() {

    }
    private void OnTriggerStay(Collider other)
    {
      //  Debug.Log("triggered");
        if (other.gameObject.name == "Torch - Model 1" && canBeRevealed == true)
        {
            if (revealed == false)
            {
                StartCoroutine(fadeobj(true));

            revealed = true;
            

            }
  


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Torch - Model 1" && canBeRevealed == true)
        {
            StartCoroutine(fadeobj(false));
            revealed = false;

        }
    }
    IEnumerator fadeobj(bool fader)
    {
        if (fader == true)
        {
            for (float f = 0; f < 1.1; f += 0.1f)
            {
                Debug.Log("reveal");
                Color c = rend.material.color;
                c.a = f;
                rend.material.color = c;
                yield return new WaitForSeconds(0.05f);
            }

           
        }
        else if (fader == false)
        {
            yield return new WaitForSeconds(2f);
            for (float f = 1; f > -0.1; f -= 0.1f)
            {
                Color c = rend.material.color;
                c.a = f;
                rend.material.color = c;
                yield return new WaitForSeconds(0.05f);
            }
         
        }
        yield return null;
    }
}
