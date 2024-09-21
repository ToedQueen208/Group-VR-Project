using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_DisableMeshRend : MonoBehaviour {

    private Renderer rend;

	// Use this for initialization
	void Start () {
        Color c;

        rend = GetComponent<Renderer>();
        c = rend.material.color;
        c.a = 0;
        rend.material.color = c;

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
