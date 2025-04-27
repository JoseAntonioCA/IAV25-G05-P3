using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CheckGhostsNear : Conditional
{
    public SharedVector3 ghost;
    public SharedVector3 ghost1;
    public SharedVector3 ghost2;
    public SharedVector3 ghost3;        
        

    public override TaskStatus OnUpdate()
    {        
        bool choque = false;
        if (Vector3.SqrMagnitude(GetComponent<Transform>().position - ghost.Value) < 10f)
        {
            choque = true;
        }
        if(Vector3.SqrMagnitude(GetComponent<Transform>().position - ghost1.Value) < 10f)
        {
            choque = true;
        }
        if (Vector3.SqrMagnitude(GetComponent<Transform>().position - ghost2.Value) < 10f)
        {
            choque = true;
        }
        if (Vector3.SqrMagnitude(GetComponent<Transform>().position - ghost3.Value) < 10f)
        {
            choque = true;
        }
        if (choque)
        {            
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }
}
