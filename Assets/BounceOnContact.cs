using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOnContact : MonoBehaviour
{
    Animator animator;
    player_move player;
    int maxCooldownTimer = 500;
    public int launchTimer = 80;
    int cooldownTimer = 0;
    bool canBounce = true;
    public float horizontalStrength = 2f;
    public float verticalStrength = 5f;

    void Start() {
        animator = GetComponent<Animator>();  
           
    }

    void Update(){
        if(!canBounce)
        {


            launchTimer--;
            if(launchTimer == 0) 
            {
                LaunchPlayer();
            }

            if(cooldownTimer > 0) cooldownTimer--;
            else canBounce = true;
        }

    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            player = other.gameObject.GetComponent<player_move>();
            if(canBounce)
            {
                canBounce = false;
                animator.SetTrigger("BounceTrigger");
                cooldownTimer = maxCooldownTimer;
                launchTimer = 20;
            }
            
        }
    }

    void LaunchPlayer(){
        if(player != null)
        {
            player.rBody.AddForce(new Vector3(horizontalStrength, verticalStrength, 0), ForceMode.Impulse);
        }
    }
}
