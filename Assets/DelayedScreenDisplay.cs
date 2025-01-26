using UnityEngine;

public class DelayedScreenDisplay : MonoBehaviour
{
    [SerializeField] private GameObject screenToShow; // The UI or cube "screen" to display
    [SerializeField] private float delayTime = 5f;    // Time in seconds before the screen appears

    private void Start()
    {
        // Start the timer to show the screen
        StartCoroutine(ShowScreenAfterDelay());
    }

    private System.Collections.IEnumerator ShowScreenAfterDelay()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayTime);

        // Show the screen
        if (screenToShow != null)
        {
            screenToShow.SetActive(true); // Activate the screen
        }
    }
}
