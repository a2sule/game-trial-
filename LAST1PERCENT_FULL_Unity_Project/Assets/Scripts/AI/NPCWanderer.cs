using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCWanderer : MonoBehaviour
{
    public float radius = 25f;
    public float decisionInterval = 5f;
    public Transform[] destinations;
    private NavMeshAgent agent;
    private float nextDecision;

    private void Awake(){agent=GetComponent<NavMeshAgent>();}
    private void Update()
    {
        if(Time.time<nextDecision)return;
        nextDecision=Time.time+decisionInterval;
        if(!agent.pathPending && (!agent.hasPath || agent.remainingDistance<2f))
            ChooseDestination();
    }

    private void ChooseDestination()
    {
        Vector3 target;
        if(destinations!=null && destinations.Length>0 && Random.value<.35f)
            target=destinations[Random.Range(0,destinations.Length)].position;
        else
            target=transform.position+Random.insideUnitSphere*radius;

        target.y=transform.position.y;
        if(NavMesh.SamplePosition(target,out NavMeshHit hit,radius,NavMesh.AllAreas))
            agent.SetDestination(hit.position);
    }
}
