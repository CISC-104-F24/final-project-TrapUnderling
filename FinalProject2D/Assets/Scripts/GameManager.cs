using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Static variable to track whether the game has started
    public static bool gameStarted = false;

    // Scene names
    public string mainMenuScene = "MainMenu";  // Main Menu scene name
    public string gameSceneName = "GameScene";  // Gameplay scene name
    public string gameOverSceneName = "GameOver";  // Game Over scene name

    void Start()
    {
        // If the game has not started yet, load the Main Menu
        if (!gameStarted)
        {
            gameStarted = true;
            SceneManager.LoadScene(0);
        }
    }

    // Call this method to start the game (e.g., when the player clicks "Start")
    public void StartGame()
    {
        // Load the gameplay scene and mark the game as started
        gameStarted = true;
        SceneManager.LoadScene(1);
    }

    // Call this method when the player loses (e.g., on Game Over)
    public void GameOver()
    {
        // Load the Game Over scene
        SceneManager.LoadScene(2);
    }
}
