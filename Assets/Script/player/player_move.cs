using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player_move : MonoBehaviour

{
    //Debugging
    public bool debugMode = true;
    public TextMeshProUGUI debugPlayerState;
    private enum PlayerState
    {
        Moving, 
        Rooted,
        Falling,
        Dead

    }
    
    private bool canRoot = false;
    private PlayerState state = PlayerState.Moving;
    public Vector3 speed = new Vector3(50, 50, 0);
    private Vector2 movement;
    private Rigidbody rBody;
    public float mSpeed = 1f;

    void Start()
    {
        debugPlayerState.enabled = debugMode;
        rBody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(debugMode)
        {
            PlayerDebug();
        }
        
        switch(state)
        {
            case(PlayerState.Moving):
                MoveBehavior();
                break;
            case(PlayerState.Rooted):
                RootedBehavior();
                break;
        }      
    }

    //State Behaviors
    void MoveBehavior()
    {
        
        transform.Translate(Vector2.right * 0.0005f * mSpeed);
        if (Input.GetKeyDown(KeyCode.Space) && canRoot)
        {

            state = PlayerState.Rooted;
        }
    }

    void RootedBehavior()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            state = PlayerState.Moving;
        }
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
        debugPlayerState.text = string.Format("Player State: {0}\nCan Root: {1}\nMouse ({2}, {3})", state, canRoot, Input.mousePosition.x, Input.mousePosition.y);
    }

}



