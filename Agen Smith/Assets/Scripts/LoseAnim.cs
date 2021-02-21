using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseAnim : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetTrigger("Animate");
    }
}
