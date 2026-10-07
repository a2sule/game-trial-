using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 4.5f;
    public float sprintSpeed = 7.5f;
    public float jumpHeight = 1.5f;
    public float gravity = -25f;
    public Transform cameraTransform;

    private CharacterController controller;
    private Vector3 velocity;

    public float Speed01 { get; private set; }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsPaused) return;

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 input = new Vector3(x,0,z).normalized;

        Vector3 forward = cameraTransform ? Vector3.Scale(cameraTransform.forward,new Vector3(1,0,1)).normalized : Vector3.forward;
        Vector3 right = cameraTransform ? cameraTransform.right : Vector3.right;
        Vector3 move = (forward * input.z + right * input.x).normalized;

        bool sprint = Input.GetKey(KeyCode.LeftShift) && input.sqrMagnitude > .01f;
        float speed = sprint ? sprintSpeed : walkSpeed;
        controller.Move(move * speed * Time.deltaTime);
        Speed01 = move.magnitude * (sprint ? 1f : .6f);

        if (move.sqrMagnitude > .01f)
        {
            Quaternion target = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation,target,12f*Time.deltaTime);
        }

        if (controller.isGrounded && velocity.y < 0) velocity.y = -2f;
        if (Input.GetButtonDown("Jump") && controller.isGrounded) velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
