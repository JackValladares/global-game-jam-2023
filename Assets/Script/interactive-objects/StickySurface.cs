using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickySurface : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            other.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            other.transform.SetParent(null);
            other.transform.rotation = Quaternion.identity;
        }
    }
}
