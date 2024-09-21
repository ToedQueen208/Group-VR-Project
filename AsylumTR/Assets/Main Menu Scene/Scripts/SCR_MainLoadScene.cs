using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_MainLoadScene : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Asylum");
        Time.timeScale = 1f;
        Cursor.visible = false;
    }
}
