using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private Animator animator;
    public enum FadeMode { In, Out }

    void Start()
    {
        animator = transform.parent.parent.GetComponent<Animator>();
    }

    public void PlayFade(FadeMode fadeMode)
    {
        if (fadeMode == FadeMode.In)
            animator.Play("FadeIn");
        else if (fadeMode == FadeMode.Out)
            animator.Play("FadeOut");
    }
}
