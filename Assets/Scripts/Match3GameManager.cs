using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Match3GameManager : MonoBehaviour
{
    [Header("UI Buttons")]
    public Image[] buttons;         // 3 кнопки
    [Header("Sprites")]
    public Sprite[] sprites;        // 3 спрайта

    [Header("Score")]
    public EggsNum score;          // текущие очки

    private System.Random rnd = new System.Random();

    public AudioSource clickSound;
    public AudioSource niceSound;
    public ParticleSystem pt;
    public ParticleSystem pt1;
    public ParticleSystem pt2;

    private void OnEnable()
    {
        ResetButtons();
    }

    // --------------------
    // BUTTON CLICK
    // --------------------
    public void OnButtonClick(int index)
    {
        if (index < 0 || index >= buttons.Length)
            return;

        // текущий спрайт кнопки
        Sprite current = buttons[index].sprite;

        // выбираем новый рандомный спрайт, который не равен текущему
        Sprite newSprite;
        do
        {
            newSprite = sprites[Random.Range(0, sprites.Length)];
        } while (newSprite == current);

        buttons[index].sprite = newSprite;
        buttons[index].SetNativeSize();
        // проверяем совпадение всех трёх
        clickSound.Play();
        CheckMatch();
    }

    // --------------------
    // CHECK MATCH
    // --------------------
    void CheckMatch()
    {
        if (buttons[0].sprite == buttons[1].sprite && buttons[1].sprite == buttons[2].sprite)
        {
            // совпали все три спрайта
            AddScore();

            // сбрасываем на новые рандомные спрайты
            ResetButtons();
        }
    }

    // --------------------
    // RESET BUTTONS
    // --------------------
    void ResetButtons()
    {
        foreach (var btn in buttons)
        {
            btn.sprite = sprites[Random.Range(0, sprites.Length)];
            btn.SetNativeSize();
        }
    }

    // --------------------
    // ADD SCORE
    // --------------------
    void AddScore()
    {
        score.Add(5); // заглушка начисления очков
        niceSound.Play();
        pt.Play();  
        pt1.Play();  
        pt2.Play();  
        Debug.Log("Score: " + score);
    }
}
