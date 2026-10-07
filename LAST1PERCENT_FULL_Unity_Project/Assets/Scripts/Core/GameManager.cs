using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("References")]
    public PlayerController player;
    public WorldClock worldClock;
    public MissionManager missionManager;

    public int Cash { get; private set; }
    public int Reputation { get; private set; }
    public int WantedLevel { get; private set; }

    public bool IsPaused { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Cash = 2000;
        Reputation = 0;
        WantedLevel = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5)) SaveSystem.Save(this);
        if (Input.GetKeyDown(KeyCode.F9)) SaveSystem.Load(this);
    }

    public void AddCash(int amount) => Cash = Mathf.Max(0, Cash + amount);

    public bool SpendCash(int amount)
    {
        if (amount < 0 || Cash < amount) return false;
        Cash -= amount;
        return true;
    }

    public void AddReputation(int amount) => Reputation = Mathf.Max(0, Reputation + amount);

    public void AddWanted(int amount)
    {
        WantedLevel = Mathf.Clamp(WantedLevel + amount, 0, 5);
        if (WantedLevel > 0) StartCoroutine(ReduceWantedAfterDelay());
    }

    private IEnumerator ReduceWantedAfterDelay()
    {
        yield return new WaitForSeconds(45f);
        WantedLevel = Mathf.Max(0, WantedLevel - 1);
    }

    public void SetPaused(bool paused)
    {
        IsPaused = paused;
        Time.timeScale = paused ? 0f : 1f;
    }
}
