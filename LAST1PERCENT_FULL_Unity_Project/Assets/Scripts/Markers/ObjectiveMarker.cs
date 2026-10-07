using UnityEngine;

public class ObjectiveMarker : MonoBehaviour
{
    public Transform target;
    public float spinSpeed=90f;
    private void Update()
    {
        transform.Rotate(0,spinSpeed*Time.deltaTime,0);
        if(target)transform.position=target.position+Vector3.up*2f;
    }
}
