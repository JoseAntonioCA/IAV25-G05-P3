using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CheckIfScape : Conditional
{

    SharedTransformList hidePoints;
    Transform hidePoint;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    public override void OnAwake()
    {
        navMeshAgent = transform.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public override TaskStatus OnUpdate()
    {
        float minDistance = 0;
        foreach(Transform tr in hidePoints.Value)
        {
            float magnitud = Vector3.SqrMagnitude(GetComponent<Transform>().position - tr.position);
            if (magnitud < minDistance)
            {
                hidePoint = tr;
                minDistance = magnitud;            
            }
        }

        navMeshAgent.SetDestination(hidePoint.position);

        return Vector3.SqrMagnitude(transform.position - hidePoint.position) < 10f ? TaskStatus.Success:TaskStatus.Running;
    }
}
