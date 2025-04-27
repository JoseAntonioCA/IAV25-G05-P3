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
        navMeshAgent.SetDestination(hidePoint.position);

        bool hide = false;
        int i = 0;
        while(!hide && i < hidePoints.Value.Count)
        { 
            //esto es como un if
            hide = Vector3.SqrMagnitude(transform.position - hidePoints.Value[i].position) < 0.01f;

            i++;
        }

        return hide ? TaskStatus.Success:TaskStatus.Running;
    }
}
