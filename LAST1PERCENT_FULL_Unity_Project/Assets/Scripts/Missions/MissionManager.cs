using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Mission
{
    public string id;
    public string title;
    public string description;
    public int reward;
    public int reputation;
    public bool active;
    public bool completed;
}

public class MissionManager : MonoBehaviour
{
    public List<Mission> missions = new List<Mission>();
    public Mission ActiveMission { get; private set; }

    private void Start()
    {
        missions.Add(new Mission{ id="delivery_01",title="First Delivery",description="Collect the package and reach the marked destination.",reward=750,reputation=5 });
        missions.Add(new Mission{ id="street_01",title="Street Favor",description="Help a local NPC by completing the favor.",reward=1200,reputation=10 });
        missions.Add(new Mission{ id="race_01",title="Beat The Clock",description="Reach the checkpoint before time runs out.",reward=2000,reputation=15 });
        Accept(missions[0]);
    }

    public void Accept(Mission mission)
    {
        if (ActiveMission != null) ActiveMission.active=false;
        ActiveMission=mission;
        ActiveMission.active=true;
    }

    public void CompleteActive()
    {
        if (ActiveMission==null || ActiveMission.completed) return;
        ActiveMission.completed=true;
        ActiveMission.active=false;
        GameManager.Instance?.AddCash(ActiveMission.reward);
        GameManager.Instance?.AddReputation(ActiveMission.reputation);
        ActiveMission=null;
    }
}
