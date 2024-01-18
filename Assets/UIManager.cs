using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    void Start()
    {
        // Ensure the game over screen is initially inactive
        gameOverScreen.SetActive(false);
    }

    public void ShowGameOverScreen()
    {
        // Activate the game over screen
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        // Quit the game (works in standalone builds)
        Application.Quit();
    }
}
