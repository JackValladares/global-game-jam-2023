using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightUpOnMouseOver : MonoBehaviour
{
     private Light myLight;


    void Start()
    {
        myLight = GetComponent<Light>();

    }

    private void OnTriggerStay(Collider other) {
        
        if(other.tag == "MouseDrag")
        {
            myLight.enabled = true;
        }
    }
        private void OnTriggerExit(Collider other) {
        
        if(other.tag == "MouseDrag")
        {
            myLight.enabled = false;
        }
    }
}
