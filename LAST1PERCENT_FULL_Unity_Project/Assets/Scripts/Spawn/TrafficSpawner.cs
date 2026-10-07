using UnityEngine;

public class TrafficSpawner : MonoBehaviour
{
    public GameObject vehiclePrefab;
    public Transform[] spawnPoints;
    public int count=12;

    [ContextMenu("Spawn Traffic")]
    public void Spawn()
    {
        if(!vehiclePrefab || spawnPoints==null || spawnPoints.Length==0)return;
        for(int i=0;i<count;i++)
        {
            Transform p=spawnPoints[i%spawnPoints.Length];
            Instantiate(vehiclePrefab,p.position,p.rotation,transform);
        }
    }
}
