using UnityEngine;
using UnityEngine.SceneManagement;  // To load scenes

public class BootManager : MonoBehaviour
{
    public string startScene = "Menu";  // Name of the scene to load first

    void Awake()
    {
        // Ensure that this script runs first and loads the desired scene
        LoadStartScene();
    }

    void LoadStartScene()
    {
        // Make sure the scene name matches exactly with the scene in Build Settings
        SceneManager.LoadScene(startScene);
    }
}
