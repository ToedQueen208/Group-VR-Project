using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_BypassLoadCredits : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Credits");
    }
}
