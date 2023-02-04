using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggableHorizontal : objectDraggable
{
    public override Vector3 ConstraintedMovement(Vector3 newPos)
    {
        newPos.y = this.transform.position.y;
        return newPos;
    }

}
