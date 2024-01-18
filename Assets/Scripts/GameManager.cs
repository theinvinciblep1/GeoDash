using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;
    public float restartDelay = 1f;

    public UIManager uiManager;

    void Start()
    {
        // Ensure the UIManager is assigned in the Unity Editor
        if (uiManager == null)
        {
            Debug.LogError("UIManager is not assigned in GameManager!");
        }
    }

    public void GameOver()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            //Invoke("Restart", restartDelay);
            uiManager.ShowGameOverScreen();
        }
    }

    //void Restart()
    //{
        // Reload the current scene
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   // }
}
