using UnityEngine;
using System.Collections; // Required for using IEnumerator and coroutines

public class InteractWithObject : MonoBehaviour
{
    public float interactionRange = 3f; // The range at which the player can interact with the object
    public float anxietyDecreaseAmount = 20f; // The amount by which the anxiety decreases per interaction
    public float interactionCooldown = 10f; // Cooldown time in seconds
    private bool canInteract = true; // If the player can interact or not
    private Anxiety anxietyScript; // Reference to the Anxiety script

    // Start is called before the first frame update
    void Start()
    {
        // Try to find the Anxiety script attached to the player or a manager
        anxietyScript = FindObjectOfType<Anxiety>();

        if (anxietyScript == null)
        {
            Debug.LogError("Anxiety script not found in the scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is within interaction range and the E key is pressed
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < interactionRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && canInteract)
            {
                Interact();
            }
        }
    }

    // Method for interaction when the player presses E
    private void Interact()
    {
        if (anxietyScript != null)
        {
            // Decrease the anxiety meter by the specified amount
            anxietyScript.DecreaseAnxiety(anxietyDecreaseAmount);

            // Start cooldown coroutine
            StartCoroutine(InteractionCooldown());
        }
    }

    // Coroutine to handle interaction cooldown
    private IEnumerator InteractionCooldown()
    {
        // Disable interaction temporarily
        canInteract = false;

        // Wait for the cooldown time to pass
        yield return new WaitForSeconds(interactionCooldown);

        // Re-enable interaction
        canInteract = true;
    }
}
