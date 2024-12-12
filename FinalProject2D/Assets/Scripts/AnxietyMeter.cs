using UnityEngine;
using UnityEngine.UI;  // Required for accessing UI components
using UnityEngine.SceneManagement; // Required for scene management

public class AnxietyMeter : MonoBehaviour
{
    // Reference to the Slider component
    public Slider anxietySlider;

    // Time it takes to fill the meter completely (in seconds)
    public float fillTime = 30f;

    // The current time elapsed
    private float timeElapsed = 0f;

    // The maximum value the anxiety meter can reach
    private float maxAnxiety = 100f;

    // The scene name to load when the meter is full
    public string jumpscareScene = "Jumpscare";

    void Start()
    {
        // Make sure the anxiety meter starts at 0
        anxietySlider.value = 0;
    }

    void Update()
    {
        // If anxiety bar isn't max -> fill bar
        if (anxietySlider.value < maxAnxiety)
        {
            // Increase the time elapsed
            timeElapsed += Time.deltaTime;

            // Calculate the new value for the slider
            float newValue = (timeElapsed / fillTime) * maxAnxiety;

            // Set the slider's value based on time elapsed
            anxietySlider.value = Mathf.Clamp(newValue, 0, maxAnxiety);
        }

        // Check if the anxiety meter is full
        if (anxietySlider.value >= maxAnxiety)
        {
            // Switch to the "Jumpscare" scene
            SceneManager.LoadScene(2);
        }
    }
}
