using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


public class Unstuck : Action
{
    public SharedGameObject totem;

    private Vector3 target;

    public override void OnAwake()
    {
        target = totem.Value.transform.position;
    }

    public override void OnStart()
    {
        //Decirle al pathfinding adonde tiene que ir o algo
    }

    public override TaskStatus OnUpdate()
    {
        if (Vector3.SqrMagnitude(transform.position - target) < 0.1f)
        {
            //Debe devolver failure para que se vuelva a reposicionarse detrás antes de ir al empuje
            return TaskStatus.Failure;
        }
        return TaskStatus.Running;
    }
}
