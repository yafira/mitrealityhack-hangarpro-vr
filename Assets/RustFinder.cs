using UnityEngine;
using System.Collections; // For IEnumerator
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleRustDetector : MonoBehaviour
{
    [Header("Raycast Settings")]
    public Transform rayOrigin; // The origin of the ray (e.g., Main Camera of the XR Rig)
    public float rayLength = 5f; // Maximum distance for ray detection

    [Header("Haptic Feedback Settings")]
    public XRController controller; // Reference to the XR Controller (for haptics)
    public float vibrationDuration = 0.2f; // Duration of the vibration
    public float vibrationAmplitude = 0.5f; // Intensity of the vibration (0 to 1)

    private void Update()
    {
        if (rayOrigin == null)
        {
            Debug.LogError("Ray Origin is not assigned! Please set the Ray Origin in the Inspector.");
            return;
        }

        // Cast a ray forward from the ray origin
        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);
        RaycastHit hit;

        // Draw the ray in the Scene view for debugging
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            // Check if the object hit has the "Rust" tag
            if (hit.collider.CompareTag("Rust"))
            {
                Debug.Log($"Rust detected on {hit.collider.name} at {hit.point}.");
                TriggerHapticFeedback();
            }
            else
            {
                Debug.Log($"No rust detected on {hit.collider.name}.");
            }
        }
        else
        {
            Debug.Log("No object detected.");
        }
    }

    private void TriggerHapticFeedback()
    {
        if (controller != null)
        {
            Debug.Log($"Triggering haptic feedback: Amplitude={vibrationAmplitude}, Duration={vibrationDuration}.");

            // Use the SendHapticImpulse method for haptic feedback
            controller.SendHapticImpulse(vibrationAmplitude, vibrationDuration);

            // Optionally, use a coroutine to stop the vibration after the specified duration
            StartCoroutine(StopVibrationAfterDelay(vibrationDuration));
        }
        else
        {
            Debug.LogWarning("XR Controller not assigned for haptic feedback. Please set the Controller in the Inspector.");
        }
    }

    private IEnumerator StopVibrationAfterDelay(float duration)
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Stop the vibration (if necessary, depending on your controller type)
        controller.SendHapticImpulse(0f, 0f); // Stop the haptic feedback
    }
}
