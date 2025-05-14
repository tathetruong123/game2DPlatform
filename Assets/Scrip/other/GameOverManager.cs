using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f; 
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Thoát game...");
        Application.Quit();
    }

    public void NewGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scene1"); 
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); 
    }
}
