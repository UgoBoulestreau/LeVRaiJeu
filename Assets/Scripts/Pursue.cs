using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : MonoBehaviour
{
    private GameObject Target;
    private UnityEngine.AI.NavMeshAgent Agent;
    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        Vector3 targetPosition = Target.transform.position;
        RunToTarget(targetPosition);
    }

    private void RunToTarget(Vector3 targetPosition)
    {
        Vector3 destination = PositionToPursue(targetPosition);
        HeadForDestination(destination);
    }

    private void HeadForDestination(Vector3 destination)
    {
        Agent.SetDestination(destination);
    }

    private Vector3 PositionToPursue(Vector3 targetPosition)
    {
        Vector3 tartgetPos = new Vector3(targetPosition.x - transform.position.x, 0, targetPosition.z - transform.position.z);

        transform.rotation = Quaternion.LookRotation(tartgetPos);
        Vector3 pursue = targetPosition + transform.forward;

        return pursue;
    }
}
