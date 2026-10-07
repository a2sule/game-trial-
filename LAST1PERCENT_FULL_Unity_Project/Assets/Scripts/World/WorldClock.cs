using UnityEngine;

public class WorldClock : MonoBehaviour
{
    [Range(0,24)] public float Hour = 8f;
    public float minutesPerRealSecond = 1f;
    public Light sun;

    private void Update()
    {
        Hour += (minutesPerRealSecond/60f)*Time.deltaTime;
        if(Hour>=24) Hour-=24;
        UpdateSun();
    }

    public void SetHour(float hour) { Hour=Mathf.Repeat(hour,24f); UpdateSun(); }

    private void UpdateSun()
    {
        if(!sun)return;
        float angle=(Hour/24f)*360f-90f;
        sun.transform.rotation=Quaternion.Euler(angle,170f,0);
        float daylight=Mathf.Clamp01(Mathf.Sin((Hour-6f)/12f*Mathf.PI));
        sun.intensity=.15f+daylight*1.1f;
    }
}
