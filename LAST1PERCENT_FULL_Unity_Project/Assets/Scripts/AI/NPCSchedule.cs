using UnityEngine;
using UnityEngine.AI;

public class NPCSchedule : MonoBehaviour
{
    public Transform home;
    public Transform work;
    public Transform leisure;
    public WorldClock clock;
    private NavMeshAgent agent;
    private int lastSlot=-1;

    private void Awake(){agent=GetComponent<NavMeshAgent>();}

    private void Update()
    {
        if(!clock)return;
        int slot=clock.Hour<7?0:clock.Hour<9?1:clock.Hour<17?2:clock.Hour<21?3:4;
        if(slot==lastSlot)return;
        lastSlot=slot;
        Transform target=slot<=0?home:slot==2?work:leisure;
        if(target)agent.SetDestination(target.position);
    }
}
