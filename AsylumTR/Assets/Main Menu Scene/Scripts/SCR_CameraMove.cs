using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_CameraMove : MonoBehaviour {

    public Button StartButton;

	void Start ()
    {
        Button SBtn = StartButton.GetComponent<Button>();
        SBtn.onClick.AddListener(MoveOnClick);   
    }

    void MoveOnClick()
    {
        transform.Translate(Vector3.forward * 1.5f * Time.fixedDeltaTime);
    }

}
