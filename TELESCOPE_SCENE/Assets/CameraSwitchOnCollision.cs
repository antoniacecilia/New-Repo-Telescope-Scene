using UnityEngine;
public class CameraSwitchOnCollision : MonoBehaviour
{
    public Camera mainCamera; // Assign your main camera to this field in the Inspector
    public Camera alternateCamera; // Assign the camera you want to switch to in the Inspector
    private bool hasSwitched = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!hasSwitched && other.CompareTag("Player")) // Adjust the tag based on your XR rig or collider's tag
        {
            SwitchCamera();
        }
    }
    private void SwitchCamera()
    {
        mainCamera.enabled = false;
        alternateCamera.enabled = true;
        hasSwitched = true;
    }
}