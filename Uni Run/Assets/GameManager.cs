using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool IsGameOver { get; private set; }

    private int score;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverUI;

    public void Awake()
    {
        gameOverUI.SetActive(false);
    }

    private void Update()
    {
        if(IsGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            IsGameOver = false;
            gameOverUI.SetActive(false);
            score = 0;
        }
    }

    public void AddScore(int add)
    {
        if (!IsGameOver)
        {
            score += add;
            scoreText.text = $"score: {score}";
        }
    }


    public void OnPlayerDead()
    {
        IsGameOver = true;
        gameOverUI.SetActive(true);
    }
}

