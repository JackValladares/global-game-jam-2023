using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class objectDraggable : MonoBehaviour
{
    public float rangeX = 2f;

    public enum StartingSide{
        left, right, center
    }
    public enum StartingHeight{
        top, bottom, center
    }
    private Light light;
    public StartingSide side = StartingSide.center;
    public StartingHeight height = StartingHeight.center;
    public float rangeY = 10f;
    public float speed = 1f;
    public abstract Vector3 ConstraintedMovement(Vector3 newPos);
    public AttachToMouse mouseCollider;
    public enum ObjectState
    {
        Idle,
        Dragging
    }
    Camera cam;
    private bool isThis;
    Transform grabPoint;
    ObjectState state;
    Vector3 mousePos;
    Vector3 startingPos;
    Vector3 grabPointPos;
    void Start()
    {
        if(mouseCollider == null) mouseCollider = AttachToMouse.instance;
        startingPos = this.transform.position;

        switch(height)
        {
            case(StartingHeight.top):
                this.transform.position = 
                new Vector3(this.transform.position.x, this.transform.position.y+rangeY, this.transform.position.z);
                break;
            case(StartingHeight.bottom):
                this.transform.position = 
                new Vector3(this.transform.position.x, this.transform.position.y-rangeY, this.transform.position.z);
                break;
            default:
                break;
        }

        switch(side)
        {
            case(StartingSide.left):
                this.transform.position = 
                new Vector3(this.transform.position.x-rangeX, this.transform.position.y, this.transform.position.z);
                break;
            case(StartingSide.right):
                this.transform.position = 
                new Vector3(this.transform.position.x+rangeX, this.transform.position.y, this.transform.position.z);
                break;
            default:
                break;
        }

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
            if(Input.GetMouseButton(0))
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
        newPos.z = this.transform.position.z;
        newPos = Vector3.Lerp(transform.position,ConstraintedMovement(newPos), Time.deltaTime * 3 * speed);

        if((newPos.x < startingPos.x+rangeX) && (newPos.x > startingPos.x-rangeX) &&
            (newPos.y < startingPos.y+rangeY) && (newPos.y > startingPos.y-rangeY))
        {
            transform.position = newPos;
        }
    }

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
        }
    }
    
}
