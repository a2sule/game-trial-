using UnityEngine;

public class ArcadeVehicleController : MonoBehaviour
{
    public float acceleration=18f;
    public float maxSpeed=22f;
    public float turnSpeed=65f;
    public float brake=25f;

    private float speed;

    private void Update()
    {
        float throttle=Input.GetAxis("Vertical");
        float steer=Input.GetAxis("Horizontal");

        if(Mathf.Abs(throttle)>.05f) speed+=throttle*acceleration*Time.deltaTime;
        else speed=Mathf.MoveTowards(speed,0,brake*Time.deltaTime);

        speed=Mathf.Clamp(speed,-maxSpeed*.4f,maxSpeed);
        transform.Rotate(0,steer*turnSpeed*Time.deltaTime*Mathf.Sign(speed==0?1:speed),0);
        transform.position+=transform.forward*speed*Time.deltaTime;
    }
}
