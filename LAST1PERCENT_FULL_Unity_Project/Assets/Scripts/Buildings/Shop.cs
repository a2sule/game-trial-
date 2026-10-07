using UnityEngine;

public class Shop : MonoBehaviour, IInteractable
{
    public string shopName="Corner Shop";
    public int healPrice=300;
    public string InteractionPrompt => "E: enter " + shopName;

    public void Interact(PlayerInteractor player)
    {
        if(GameManager.Instance!=null && GameManager.Instance.SpendCash(healPrice))
        {
            Health h=player.GetComponent<Health>();
            if(h)h.Heal(35);
            Debug.Log("Bought health from "+shopName);
        }
        else Debug.Log("Not enough cash.");
    }
}
