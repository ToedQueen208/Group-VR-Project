using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{



    [RequireComponent(typeof(CharacterController))]
    public class SCR_SafePuzzle : MonoBehaviour
    {
        [SerializeField] private int[] correctNum;
        [SerializeField] private int[] userNum;
        bool bIsComplete;
        int counter;
        [SerializeField] Text numtext;
        int correct = 0;
        [SerializeField] CharacterController character;
        [SerializeField] private MouseLook m_MouseLook;
        [SerializeField] Canvas safeCanvas;
        public bool safeopen = false;
        [SerializeField] private GameObject button;
        [SerializeField] private FirstPersonController fps;
        [SerializeField] private SCR_EndGame puzzlecounter;
        public Canvas Canvas;

        bool completed = false;
        // Use this for initialization
        void Start()
        {
            safeCanvas.enabled = false;
            button.SetActive(false);
            Canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        }

        // Update is called once per frame
        void Update()
        {
            if (completed == true)
            {
                safeCanvas.enabled = false;
                safeopen = false;
                m_MouseLook.UpdateCursorLock();
                gameObject.GetComponent<Collider>().enabled = false;
                character.enabled = true;
                fps.enabled = true;
            }
        }
        public void userInput(int num)
        {
            //display canvas saying to inpit number
            //outpt number as they go
            if (counter < 7)
            {
                counter += 1;
                userNum[counter - 1] = num;

            }

            numtext.text = "";
            for (int i = 0; i < counter; i++)
            {
                numtext.text += userNum[i].ToString();

            }


        }
        public void checkinput()
        {
            for (int i = 0; i < 4; i++)
            {
                if (correctNum[i] == userNum[i])
                {
                    correct += 1;
                }

            }
            if (correct == 4)
            {
                numtext.text = "Correct";
                button.SetActive(true);
                completed = true;
                puzzlecounter.puzzledone[2] = true;
                safeCanvas.enabled = false;

            }
            else
            {
                clearInput();

            }
        }

        public void clearInput()
        {
            numtext.text = "cleared";
            counter = 0;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            {
                safeCanvas.enabled = true;
                fps.enabled = false;
                character.enabled = false;
                safeopen = true;
                m_MouseLook.UpdateCursorLock();
                m_MouseLook.SetCursorLock(true);
                fps.enabled = false;
                character.enabled = false;
                Canvas.GetComponent<SCR_PauseMenu>().enabled = false;
            }
            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
            {
              
                safeCanvas.enabled = false;
                safeopen = false;
                m_MouseLook.UpdateCursorLock();
                //m_MouseLook.SetCursorLock(false);
                character.enabled = true;
                fps.enabled = true;
                Canvas.GetComponent<SCR_PauseMenu>().enabled = true;
            }
        }
    }
}
