using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public float distance = 3f;
    public Camera cam;
    public string CurrentPrompt { get; private set; }

    private void Update()
    {
        CurrentPrompt = "";
        if (!cam) return;

        Ray ray = new Ray(cam.transform.position,cam.transform.forward);
        if (Physics.Raycast(ray,out RaycastHit hit,distance))
        {
            IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();
            if (interactable != null)
            {
                CurrentPrompt = interactable.InteractionPrompt;
                if (Input.GetKeyDown(KeyCode.E)) interactable.Interact(this);
            }
        }
    }
}
