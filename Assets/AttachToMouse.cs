using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToMouse : MonoBehaviour
{
    public static AttachToMouse instance;
    void Start()
    {
        instance = this;
    }
    void Update()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 0;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
        
    }
}
