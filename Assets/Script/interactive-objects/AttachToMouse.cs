using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToMouse : MonoBehaviour
{
    public bool isAttached = false;
    public static AttachToMouse instance;
    void Start()
    {
        instance = this;
    }
    void Update()
    {
        Vector3 pos;
        pos = Input.mousePosition;
        pos.z = 10;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
        
    }
}
