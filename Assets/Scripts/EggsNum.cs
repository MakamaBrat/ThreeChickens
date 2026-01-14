using UnityEngine;
using TMPro;

public class EggsNum : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text scoreText2;

    private int score;

    private const string BEST_EGGS_KEY = "BEST_EGGS";

    void OnEnable()
    {
        score = 0;
        UpdateText();
    }

    void UpdateText()
    {
        scoreText.text = score.ToString();
        scoreText2.text = score.ToString();
    }

    public void Add(int amount = 1)
    {
        score += amount;
        UpdateText();
        SaveBestScore();
    }

    void SaveBestScore()
    {
        int best = PlayerPrefs.GetInt(BEST_EGGS_KEY, 0);

        if (score > best)
        {
            PlayerPrefs.SetInt(BEST_EGGS_KEY, score);
            PlayerPrefs.Save();
        }
    }

    public int GetSnowflakes()
    {
        return score;
    }
}
