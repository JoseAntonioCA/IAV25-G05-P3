using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

public class CheckGhostsNear : Conditional
{
    public SharedVector3 ghost;
    public SharedVector3 ghost1;
    public SharedVector3 ghost2;
    public SharedVector3 ghost3;

    private NavMeshAgent navMeshAgent;

    public override void OnAwake()
    {
        navMeshAgent = transform.gameObject.GetComponent<NavMeshAgent>();
    }

    public override TaskStatus OnUpdate()
    {        
        bool choque = false;
        if (Vector3.SqrMagnitude(GetComponent<Transform>().position - ghost.Value) < 20f)
        {
            choque = true;
        }
        if(Vector3.SqrMagnitude(GetComponent<Transform>().position - ghost1.Value) < 20f)
        {
            choque = true;
        }
        if (Vector3.SqrMagnitude(GetComponent<Transform>().position - ghost2.Value) < 20f)
        {
            choque = true;
        }
        if (Vector3.SqrMagnitude(GetComponent<Transform>().position - ghost3.Value) < 20f)
        {
            choque = true;
        }
        if (choque)
        {            
            navMeshAgent.SetDestination(transform.position);
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }
}
