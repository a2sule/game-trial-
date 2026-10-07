using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Text cashText;
    public Text reputationText;
    public Text wantedText;
    public Text promptText;
    public Text missionText;

    public PlayerInteractor interactor;

    private void Update()
    {
        GameManager gm=GameManager.Instance;
        if(gm!=null)
        {
            if(cashText)cashText.text="₦"+gm.Cash.ToString("N0");
            if(reputationText)reputationText.text="REP "+gm.Reputation;
            if(wantedText)wantedText.text=new string('★',gm.WantedLevel)+new string('☆',5-gm.WantedLevel);
        }
        if(promptText)promptText.text=interactor?interactor.CurrentPrompt:"";
        if(missionText && gm!=null && gm.missionManager!=null && gm.missionManager.ActiveMission!=null)
            missionText.text=gm.missionManager.ActiveMission.title+" — "+gm.missionManager.ActiveMission.description;
    }
}
