using UnityEngine;

public class ScreenSwitcher : MonoBehaviour
{
    // Assign these in the Unity Inspector
    [SerializeField] private GameObject currentScreen;  // The screen to hide
    [SerializeField] private GameObject newScreen;      // The screen to show

    // Method to switch screens
    public void SwitchScreens()
    {
        if (currentScreen != null) currentScreen.SetActive(false); // Hide the current screen
        if (newScreen != null) newScreen.SetActive(true);          // Show the new screen
    }
}
