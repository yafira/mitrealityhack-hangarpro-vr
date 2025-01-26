using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource airplaneAudioSource; // AudioSource for Airplane Fly By
    private AudioSource windAudioSource; // AudioSource for Wind

    void Start()
    {
        // Get the child AudioSources
        Transform airplaneTransform = transform.Find("Airplane Fly By");
        Transform windTransform = transform.Find("Wind");

        if (airplaneTransform == null || windTransform == null)
        {
            Debug.LogError("Child objects 'Airplane Fly By' or 'Wind' are missing!");
            return;
        }

        airplaneAudioSource = airplaneTransform.GetComponent<AudioSource>();
        windAudioSource = windTransform.GetComponent<AudioSource>();

        if (airplaneAudioSource == null || windAudioSource == null)
        {
            Debug.LogError("AudioSource components are missing on child objects!");
        }

        // Ensure that the airplane audio is set to not loop
        airplaneAudioSource.loop = false;

        // Test the sounds immediately to verify the issue
        airplaneAudioSource.Play();
        windAudioSource.Play();
    }
}
