using UnityEngine;
using UnityEngine.UI; // For using UI Slider
using System.Collections; // Required for using IEnumerator and coroutines
using UnityEngine.SceneManagement; // Required for scene management

public class Anxiety : MonoBehaviour
{
    // Reference to the Slider (Anxiety Bar UI)
    public Slider anxietyBar;

    // Set maximum and minimum values for the Anxiety Bar
    public float maxAnxiety = 100f;
    public float anxietyFillSpeed = 5f; // The speed at which the anxiety fills up over time
    private float currentAnxiety = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the anxiety bar starts at 0
        if (anxietyBar != null)
        {
            anxietyBar.maxValue = maxAnxiety; // Set the maximum value for the anxiety bar
            anxietyBar.value = 0f; // Start with the anxiety bar empty
        }
        else
        {
            Debug.LogError("Anxiety bar Slider is not assigned!");
        }

        // Start the Coroutine to fill the anxiety bar over time
        StartCoroutine(FillAnxietyBar());
    }

    // Coroutine to fill the anxiety bar over time
    private IEnumerator FillAnxietyBar()
    {
        while (currentAnxiety < maxAnxiety)
        {
            currentAnxiety += anxietyFillSpeed * Time.deltaTime; // Increase anxiety over time
            anxietyBar.value = currentAnxiety;

            // If the anxiety bar is full, load the Jumpscare scene
            if (currentAnxiety >= maxAnxiety)
            {
                LoadJumpscareScene();
                yield break; // Exit the coroutine after switching scenes
            }

            // Wait until the next frame
            yield return null;
        }
    }

    // Method to decrease anxiety (called from other scripts like InteractWithObject)
    public void DecreaseAnxiety(float amount)
    {
        if (anxietyBar != null)
        {
            currentAnxiety -= amount;

            // Ensure the anxiety value doesn't go below 0
            if (currentAnxiety < 0)
            {
                currentAnxiety = 0;
            }

            // Update the Slider's value
            anxietyBar.value = currentAnxiety;
        }
        else
        {
            Debug.LogError("Anxiety bar Slider is not assigned!");
        }
    }

    // Optional: If you want to reset the anxiety bar back to full (100) later
    public void ResetAnxiety()
    {
        if (anxietyBar != null)
        {
            currentAnxiety = maxAnxiety; // Reset the anxiety to max
            anxietyBar.value = currentAnxiety; // Update the UI
        }
        else
        {
            Debug.LogError("Anxiety bar Slider is not assigned!");
        }
    }

    // Method to load the Jumpscare scene when anxiety is full
    private void LoadJumpscareScene()
    {
        // Assuming the Jumpscare scene is named "Jumpscare" in your Build Settings
        SceneManager.LoadScene("Jumpscare");
    }
}
