using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class MoveBehind : Action
{
    public SharedVector3 behind;

    public override void OnStart()
    {
        //Decirle al pathfinding adonde tiene que ir o algo
    }

    public override TaskStatus OnUpdate()
    {
        if (Vector3.SqrMagnitude(transform.position - behind.Value) < 0.1f)
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
    }
}
