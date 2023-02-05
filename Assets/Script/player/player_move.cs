using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player_move : MonoBehaviour

{
    public bool falling = false;
    private CapsuleCollider cCollider;
    public Transform rotationParent;
    //Debugging
    public bool debugMode = true;
    public TextMeshProUGUI debugPlayerState;
    public enum PlayerState
    {
        Moving, 
        Rooted,
        Falling,
        Dead

    }
    
    private bool canRoot = false;
    public PlayerState state = PlayerState.Moving;
    public Vector3 speed = new Vector3(50, 50, 0);
    private Vector2 movement;
    public Rigidbody rBody;
    public float mSpeed = 1f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        debugPlayerState.enabled = debugMode;
        rBody = gameObject.GetComponent<Rigidbody>();
        cCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        

        if(rotationParent != null)
        {
            rBody.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
            Vector3 parentRotation = rotationParent.eulerAngles;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, parentRotation.z));
        }else{
            transform.rotation = Quaternion.identity;
            rBody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
        }

        if(debugMode)
        {
            PlayerDebug();
        }
        
        switch(state)
        {
            case(PlayerState.Moving):
                animator.SetBool("Rooted", false);
                MoveBehavior();
                animator.SetBool("falling", falling);
                break;
            case(PlayerState.Rooted):
                animator.SetBool("Rooted", true);
                RootedBehavior();
                break;
        }      
    }


    //State Behaviors
    void MoveBehavior()
    {
        if(animator.GetBool("canUnroot")) animator.SetBool("canUnroot", false);
        transform.Translate(Vector2.right * 0.0005f * mSpeed);
        if (Input.GetKeyDown(KeyCode.Space) && canRoot && state != PlayerState.Rooted && !falling)
        {
            rBody.AddForce(new Vector3(2f, 2f, 0), ForceMode.Impulse);
            state = PlayerState.Rooted;
        }
        falling = !CheckGrounded();
    }

    bool CheckGrounded()
    {
        
        Debug.DrawRay(new Vector3(transform.position.x-.1f, transform.position.y-.55f, transform.position.z), Vector3.down*.3f, Color.green);
        Debug.Log(Physics.Raycast(new Vector3(transform.position.x-.1f, transform.position.y-.55f, transform.position.z), Vector3.down, .3f));
        return Physics.Raycast(new Vector3(transform.position.x-.1f, transform.position.y-.55f, transform.position.z), Vector3.down, .3f);
    }

    void RootedBehavior()
    {
        
        if(!Input.GetKey(KeyCode.Space) && animator.GetBool("canUnroot"))
        {
            state = PlayerState.Moving;
            toggleUnroot();
        }
    }

    public void toggleUnroot()
    {
        animator.SetBool("canUnroot", !animator.GetBool("canUnroot"));
    }

    //Collision checking
    void OnCollisionEnter(Collision collision) {
        
        if(collision.gameObject.tag == "Rootable")
        {
            canRoot = true;
        }

    }
    void OnCollisionExit(Collision collision)
    {
        canRoot = false;
    }
 
    void PlayerDebug()
    {
        debugPlayerState.text = string.Format("Player State: {0}\nCan Root: {1}\nGrounded: {2}", state, canRoot, !falling);
    }

}



