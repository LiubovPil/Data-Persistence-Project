using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Update()
    {
        if (animator.GetBool("isShow"))
        {
            animator.CrossFade("Show", 0.0f);
        }
        else
        {
            animator.CrossFade("Hide", 0.0f);
        }
    }
}
