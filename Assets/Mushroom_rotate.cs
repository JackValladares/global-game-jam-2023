using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_rotate : MonoBehaviour
{
    ConfigurableJoint joint;
    void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
