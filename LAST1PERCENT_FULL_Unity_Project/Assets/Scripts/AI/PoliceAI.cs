using UnityEngine;
using UnityEngine.AI;

public class PoliceAI : MonoBehaviour
{
    public Transform player;
    public float chaseDistance=35f;
    public float arrestDistance=2f;
    public NavMeshAgent agent;

    private void Awake(){if(!agent)agent=GetComponent<NavMeshAgent>();}

    private void Update()
    {
        if(!player || GameManager.Instance==null || GameManager.Instance.WantedLevel<=0)return;
        float d=Vector3.Distance(transform.position,player.position);
        if(d<chaseDistance)
        {
            agent.SetDestination(player.position);
            if(d<arrestDistance)
            {
                Health h=player.GetComponent<Health>();
                if(h)h.Damage(20f);
                GameManager.Instance.AddWanted(-1);
            }
        }
    }
}
