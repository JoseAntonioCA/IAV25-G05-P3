using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

public class NeedToBreakStatues : Conditional
{
    public SharedVector3 gargola;
    public SharedVector3 gargola1;
    public SharedVector3 gargola2;
    public SharedVector3 gargola3;
    public SharedVector3 gargola4;

    private NavMeshAgent navMeshAgent;

    public override void OnAwake()
    {
        navMeshAgent = transform.gameObject.GetComponent<NavMeshAgent>();
    }

    public override TaskStatus OnUpdate()
    {        
        bool pickUp = false;        
        if (Vector3.SqrMagnitude(GetComponent<Transform>().position - gargola.Value) < 30f)
        {
            pickUp = true;
        }
        if (Vector3.SqrMagnitude(GetComponent<Transform>().position - gargola1.Value) < 30f)
        {
            pickUp = true;
        }
        if (Vector3.SqrMagnitude(GetComponent<Transform>().position - gargola2.Value) < 30f)
        {
            pickUp = true;
        }
        if (Vector3.SqrMagnitude(GetComponent<Transform>().position - gargola3.Value) < 30f)
        {
            pickUp = true;
        }
        if (Vector3.SqrMagnitude(GetComponent<Transform>().position - gargola4.Value) < 30f)
        {
            pickUp = true;
        }
        if (pickUp)
        {            
            navMeshAgent.SetDestination(transform.position);
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }
}
