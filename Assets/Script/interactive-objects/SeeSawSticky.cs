using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSawSticky : MonoBehaviour
{
    player_move player;

     private void OnCollisionEnter(Collision other) {
        
        if(other.gameObject.tag == "Player")
        {
            player = other.gameObject.GetComponent<player_move>();
            player.rotationParent = this.transform;
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            player.rotationParent = null;
            player = null;
        }
    }

}
