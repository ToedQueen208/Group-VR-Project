using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [RequireComponent(typeof(CharacterController))]

    public class SCR_PauseMenu : MonoBehaviour
    {
        public static bool GamePaused = false;

        public GameObject PauseMenu;

        public GameObject OptionsMenu;

        private bool ToggledOn;


        [SerializeField] private FirstPersonController fps;

        void Update()
        {
           if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GamePaused)
                {
                    Resume();
        
                }
                else
                {
                    Pause();
                }
            } 
        }

        public void Resume()
        {

            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            GamePaused = false;
            OptionsMenu.SetActive(ToggledOn);
            Cursor.visible = false;
            GameObject Player1 = GameObject.FindWithTag("Player");
            Player1.GetComponent<FirstPersonController>().enabled = true;
        }

        void Pause()
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GamePaused = true;
            Cursor.visible = true;
            GameObject Player1 = GameObject.FindWithTag("Player");
            Player1.GetComponent<FirstPersonController>().enabled = false;
        }

        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void Quit()
        {
            Application.Quit();
        }


    }
}
