using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public float px, py, pz;
    public int cash;
    public int reputation;
    public int wanted;
    public float worldHour;
}

public static class SaveSystem
{
    private static string Path => System.IO.Path.Combine(Application.persistentDataPath, "last1percent_save.json");

    public static void Save(GameManager gm)
    {
        if (gm == null) return;
        var p = gm.player != null ? gm.player.transform.position : Vector3.zero;
        var data = new SaveData {
            px=p.x, py=p.y, pz=p.z,
            cash=gm.Cash, reputation=gm.Reputation, wanted=gm.WantedLevel,
            worldHour=gm.worldClock != null ? gm.worldClock.Hour : 8f
        };
        File.WriteAllText(Path, JsonUtility.ToJson(data, true));
        Debug.Log("LAST 1% saved: " + Path);
    }

    public static void Load(GameManager gm)
    {
        if (!File.Exists(Path) || gm == null) return;
        var data = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path));
        if (gm.player != null) gm.player.transform.position = new Vector3(data.px,data.py,data.pz);
        typeof(GameManager).GetProperty("Cash")?.SetValue(gm, data.cash);
        typeof(GameManager).GetProperty("Reputation")?.SetValue(gm, data.reputation);
        typeof(GameManager).GetProperty("WantedLevel")?.SetValue(gm, data.wanted);
        if (gm.worldClock != null) gm.worldClock.SetHour(data.worldHour);
    }
}
