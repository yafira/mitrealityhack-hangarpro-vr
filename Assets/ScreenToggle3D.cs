using UnityEngine;

public class ScreenToggle3D : MonoBehaviour
{
    [SerializeField] private GameObject screenToHide; // The cube acting as the screen
    [SerializeField] private GameObject button;      // The button cube to detect clicks

    private void Start()
    {
        // Ensure the button has a Collider for interaction
        if (!button.TryGetComponent<Collider>(out _))
        {
            button.AddComponent<BoxCollider>();
        }
    }

    // This function will be called when the button is clicked
    public void HideScreen()
    {
        if (screenToHide != null)
        {
            screenToHide.SetActive(false); // Hide the screen
        }
    }

    private void OnMouseDown()
    {
        // Detect clicks on the button cube
        if (Input.GetMouseButtonDown(0))
        {
            HideScreen();
        }
    }
}
