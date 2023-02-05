using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIdle : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void setIdle() {
        animator.SetBool("idle", true);
    }

    public void unsetIdle()
    {
        animator.SetBool("idle", true);
    }
}
