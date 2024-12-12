using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuStart : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    
    
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
