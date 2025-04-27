using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;
using Unity.VisualScripting;

public class SetHidePoint : Action
{

    SharedTransformList hidePoints;
    Transform hidePoint;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    public override void OnAwake()
    {
        navMeshAgent = transform.gameObject.GetComponent<NavMeshAgent>();
    }
    public override void OnStart()
    {
        navMeshAgent.SetDestination(hidePoint.position);
    }
}
