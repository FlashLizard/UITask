using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void Switch()
    {
        animator.enabled = !animator.enabled;
    }
}
