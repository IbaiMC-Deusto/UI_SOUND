using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject textPause;

    private bool isPaused;
    private int score = 0;

    private void Start()
    {
        scoreText.text = $"Points: {score}";
    }

    private void Update()
    {
        if (isPaused) return;

        HealthBarCheck();
        ScoreCheck();
    }

    private void HealthBarCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeHealth(-0.1f);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeHealth(0.1f);
        }
    }

    private void ChangeHealth(float cuantity)
    {
        healthBar.value += cuantity;
    }

    private void ScoreCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GainScore();
        }
    }

    private void GainScore()
    {
        score++;
        scoreText.text = $"Points: {score}";
    }

    public void Pause()
    {
        if (isPaused) {
            Time.timeScale = 1;
            textPause.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            textPause.SetActive(true);
        }

        isPaused = !isPaused;
    }
}
