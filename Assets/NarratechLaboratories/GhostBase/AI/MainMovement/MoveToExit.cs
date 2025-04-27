using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

public class MoveToExit : Action
{
    public SharedVector3 exit;
    private NavMeshAgent navMeshAgent; 
    Animator m_Animator;

    public override void OnAwake()
    {
        navMeshAgent = transform.gameObject.GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
    }

    public override TaskStatus OnUpdate()
    {
        navMeshAgent.SetDestination(exit.Value);
        m_Animator.SetBool("IsWalking", true);
        return TaskStatus.Success;
        /*
        //        navMeshAgent.SetDestination(transform.position);
        if (Vector3.SqrMagnitude(transform.position - exit.Value) < 0.01f)
        {            
            return TaskStatus.Success;
        }        
        return TaskStatus.Running;*/
    }
}
