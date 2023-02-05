using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    HingeJoint hj;
    void Start()
    {
        hj = GetComponent<HingeJoint>();
    }
    void Update()
    {
        transform.Rotate (new Vector3 (0, 0, 2) * Time.deltaTime);
    }
}
