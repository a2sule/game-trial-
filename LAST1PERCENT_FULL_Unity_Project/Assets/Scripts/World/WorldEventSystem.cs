using UnityEngine;
using System.Collections;

public class WorldEventSystem : MonoBehaviour
{
    public float interval = 60f;
    private void Start(){StartCoroutine(Loop());}

    private IEnumerator Loop()
    {
        while(true)
        {
            yield return new WaitForSeconds(interval);
            TriggerRandomEvent();
        }
    }

    private void TriggerRandomEvent()
    {
        int e=Random.Range(0,4);
        switch(e)
        {
            case 0:
                GameManager.Instance?.AddCash(250);
                Debug.Log("WORLD EVENT: A stranger rewarded the player.");
                break;
            case 1:
                GameManager.Instance?.AddReputation(3);
                Debug.Log("WORLD EVENT: Street reputation increased.");
                break;
            case 2:
                GameManager.Instance?.AddWanted(1);
                Debug.Log("WORLD EVENT: Police activity increased.");
                break;
            case 3:
                Debug.Log("WORLD EVENT: City rush hour started.");
                break;
        }
    }
}
