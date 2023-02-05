using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggableVertical : objectDraggable
{
    public override Vector3 ConstraintedMovement(Vector3 newPos)
    {
        newPos.x = this.transform.position.x;
        return newPos;
    }

}
