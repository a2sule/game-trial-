using UnityEngine;

public class CashPickup : MonoBehaviour, IInteractable
{
    public int amount = 100;
    public string InteractionPrompt => "Press E to collect ₦" + amount;

    public void Interact(PlayerInteractor player)
    {
        GameManager.Instance?.AddCash(amount);
        GameManager.Instance?.AddReputation(1);
        Destroy(gameObject);
    }
}
