using UnityEngine;

public class TearFinder : MonoBehaviour
{
    public Transform rayOrigin; //  origin your controller or hand)
    public float rayLength = 5f; //length of ray 

    void Update()
    {
        // Cast ray forward from the ray origin
        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            // Check if the object has the "Rust" tag
            if (hit.collider.CompareTag("Tear"))
            {
                Debug.Log("Tear detected!");
            }
            else
            {
                Debug.Log("No Tire Tear detected.");
            }
        }
        else
        {
            Debug.Log("No object detected.");
        }
    }
}

