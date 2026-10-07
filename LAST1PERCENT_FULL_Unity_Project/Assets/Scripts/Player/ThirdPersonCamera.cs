using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float height = 2.2f;
    public float sensitivity = 3f;
    public float smooth = 12f;
    public float minPitch = -25f;
    public float maxPitch = 65f;

    private float yaw;
    private float pitch = 12f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        if (!target) return;

        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch,minPitch,maxPitch);

        Quaternion rot = Quaternion.Euler(pitch,yaw,0);
        Vector3 desired = target.position + rot * new Vector3(0,height,-distance);

        transform.position = Vector3.Lerp(transform.position,desired,1f-Mathf.Exp(-smooth*Time.deltaTime));
        transform.LookAt(target.position + Vector3.up * 1.4f);
    }
}
