using UnityEngine;

public class CrowdSpawner : MonoBehaviour
{
    public GameObject npcPrefab;
    public int count=40;
    public float radius=60f;
    public Transform player;

    [ContextMenu("Spawn Crowd")]
    public void Spawn()
    {
        if(!npcPrefab)return;
        for(int i=0;i<count;i++)
        {
            Vector2 p=Random.insideUnitCircle*radius;
            Vector3 pos=new Vector3(p.x,0,p.y)+(player?player.position:transform.position);
            GameObject npc=Instantiate(npcPrefab,pos,Quaternion.Euler(0,Random.Range(0,360),0),transform);
            npc.name="Citizen_"+i;
        }
    }
}
