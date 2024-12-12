using UnityEngine;
using UnityEngine.SceneManagement;  // For scene management
using System.Collections;  // Add this for IEnumerator and coroutines

public class JumpscareAudioManager : MonoBehaviour
{
    public AudioSource jumpscareAudio;  // Reference to the AudioSource component
    public string gameOverScene = "GameOver";  // Name of the Game Over scene

    void Start()
    {
        // Start playing the audio immediately
        jumpscareAudio.Play();

        // Start a coroutine to wait for the audio to finish, then change the scene
        StartCoroutine(WaitForAudioToFinish());
    }

    // Coroutine to wait for the audio to finish and then load the Game Over scene
    IEnumerator WaitForAudioToFinish()
    {
        // Wait until the audio is no longer playing
        yield return new WaitUntil(() => !jumpscareAudio.isPlaying);

        // Once the audio finishes, load the Game Over scene
        SceneManager.LoadScene(3);
    }   
}
