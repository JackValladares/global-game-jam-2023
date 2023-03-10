using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpinnable : MonoBehaviour
{
    public float speed = 1f;
    private Light light;
    public AttachToMouse mouseCollider;
    public enum ObjectState
    {
        Idle,
        Dragging
    }
    Camera cam;
    Transform grabPoint;
    ObjectState state;
    Vector3 mousePos;
    Vector3 startingPos;
    Vector3 grabPointPos;
    void Start()
    {

        if(mouseCollider == null) mouseCollider = AttachToMouse.instance;
        //mouseCollider = AttachToMouse.instance;
        foreach(Transform child in gameObject.transform)
        {
            if(child.tag == "GrabPoint")
            {
                grabPoint = child;
                light = grabPoint.GetComponent<Light>();
                light.enabled = false;
            }
        }
    }

    void Update() {
        switch(state){
            case(ObjectState.Idle):
                break;
            case(ObjectState.Dragging):
                Dragging();
                break;
        }
    }

    private void OnTriggerStay(Collider other) {
        light.enabled = true;
        if(other.tag == "MouseDrag")
        {
            if(Input.GetMouseButton(0) && !other.GetComponent<AttachToMouse>().isAttached)
            {
                state = ObjectState.Dragging;
            }else{
                state = ObjectState.Idle;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        light.enabled = false;
        if(other == mouseCollider)
        {
            state = ObjectState.Idle;
        }
    }
    void Dragging()
    {
        Vector3 newPos = mouseCollider.transform.position;
        Debug.Log(newPos.y);
        Debug.Log(grabPoint.position.y);


        if(newPos.y > grabPoint.position.y)
        {
            transform.Rotate (new Vector3 (0, 0, -50) * Time.deltaTime);
        }else{
            transform.Rotate (new Vector3 (0, 0, 50) * Time.deltaTime);
        }
    }
    
}
