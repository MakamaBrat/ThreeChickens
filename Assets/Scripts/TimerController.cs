using UnityEngine;
using TMPro;
using System.Collections;

public class TimerController : MonoBehaviour
{
    public MenuTravel menuTravel;
    [Header("UI")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float startTime = 60f; // Время таймера в секундах

    public string gameOverMethodName = "GameOver"; // имя метода GameOver

    private float currentTime;
    private bool isRunning;

    private void OnEnable()
    {
        RestartTimer();
    }

    private void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            UpdateView();
            isRunning = false;
            TriggerGameOver();
            return;
        }

        UpdateView();
    }

    // --------------------
    // RESTART TIMER
    // --------------------
    public void RestartTimer()
    {
        currentTime = startTime;
        isRunning = true;
        UpdateView();
    }

    // --------------------
    // UPDATE VIEW
    // --------------------
    void UpdateView()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    // --------------------
    // GAME OVER
    // --------------------
    void TriggerGameOver()
    {
        menuTravel.makeMenu(3);
    }
}
