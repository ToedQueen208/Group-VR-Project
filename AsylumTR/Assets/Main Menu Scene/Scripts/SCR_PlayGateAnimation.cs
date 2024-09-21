using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayGateAnimation : MonoBehaviour
{

    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0f;
    }

    public void animatorOpen()
    {
        animator.Play("GateOpening");
        animator.speed = 1f;

    }

    void Update()
    {

    }
}
