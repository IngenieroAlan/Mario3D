using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject gameOverPanel;
    public GameObject winnerPanel;
    public PlayerController playerController;
    public CameraController cameraController;
    private int score = 0;
    private int lives = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addScore(int num)
    {
        score += num;
        scoreText.text = $"Puntuación: {score}";
    }
    public void subtractScore(int num)
    {
        score -= num;
        scoreText.text = $"Puntuación: {score}";
    }
    public void takeLife()
    {
        lives--;
        if (lives < 0)
        {
            gameOver();
        }
        else { 
            livesText.text = $"Vidas: {lives}";
        }
    }
    public void addLife()
    {
        lives++;
        livesText.text = $"Vidas: {lives}";
    }
    private void gameOver()
    {
        gameOverPanel.SetActive(true);
        playerController.enabled = false;
        cameraController.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        /*gameOverPanel.SetActive(false);
        playerController.RestartCheckpoint();
        playerController.enabled = true;
        cameraController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        score = 0; 
        scoreText.text = $"Puntuación: {score}";
        lives = 5;
        livesText.text = $"Vidas: {lives}";*/

    }
    public void salir() {
        Application.Quit();
    }
    public void winner()
    {
        winnerPanel.SetActive(true);
        playerController.enabled = false;
        cameraController.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
}