using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class PushToObjective : Action
{
    public float speed = 0.1f;
    public SharedVector3 objective;

    public override TaskStatus OnUpdate()
    {
        if (Vector3.SqrMagnitude(transform.position - objective.Value) < 0.1f)
        {
            return TaskStatus.Success;
        }
        //Habria que cambiar el movimiento para hacerlo con pathfinding supongo?? 
        transform.position = Vector3.MoveTowards(transform.position, objective.Value, speed * Time.deltaTime);
        return TaskStatus.Running;
    }
}
