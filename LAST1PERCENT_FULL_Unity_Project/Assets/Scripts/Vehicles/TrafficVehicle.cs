using UnityEngine;

public class TrafficVehicle : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed=8f;
    public float reachDistance=2f;
    private int index;

    private void Update()
    {
        if(waypoints==null||waypoints.Length==0)return;
        Transform target=waypoints[index];
        Vector3 flat=target.position-transform.position; flat.y=0;
        if(flat.magnitude<reachDistance){index=(index+1)%waypoints.Length;return;}
        Vector3 dir=flat.normalized;
        transform.position+=dir*speed*Time.deltaTime;
        if(dir.sqrMagnitude>.01f)transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(dir),5f*Time.deltaTime);
    }
}
