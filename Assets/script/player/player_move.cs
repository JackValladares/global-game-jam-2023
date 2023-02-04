using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{

    public Vector3 speed = new Vector3(50, 50, 0);
    private Vector2 movement;
    private Rigidbody rBody;
    public float mSpeed = 1f;

    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!Input.GetKeyDown("space"))
        {
            transform.Translate(Vector2.right * 0.0005f * mSpeed);
        }else{
            transform.Translate(Vector2.right * 0);
        }

        
    }
}
 

