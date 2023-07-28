using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class CameraSwitchOnCollision : MonoBehaviour
{
    public Camera mainCamera;
    public Camera alternateCamera;
    public bool hasSwitched = false;
    public float panSpeed = 1.0f;
    public float maxRotation = 45f;
    private float currentRotation = 0f;
    public float switchBackDelay = 5f; // Added this line to define the delay

    private void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);

        if (hasSwitched)
        {
            float horizontalInput = primary2DAxisValue.x;
            float desiredRotation = currentRotation + horizontalInput * panSpeed;
            desiredRotation = Mathf.Clamp(desiredRotation, -maxRotation, maxRotation);
            float rotationThisFrame = desiredRotation - currentRotation;

            alternateCamera.transform.Rotate(0, rotationThisFrame, 0);
            currentRotation = desiredRotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasSwitched && other.CompareTag("Player"))
        {
            SwitchCamera();
            StartCoroutine(SwitchBackAfterDelay());
        }
    }

    private void SwitchCamera()
    {
        mainCamera.enabled = false;
        alternateCamera.enabled = true;
        hasSwitched = true;
    }

    private IEnumerator SwitchBackAfterDelay()
    {
        yield return new WaitForSeconds(switchBackDelay); // Modified this line to use the switchBackDelay variable
        SwitchToMainCamera();
    }

    private void SwitchToMainCamera()
    {
        mainCamera.enabled = true;
        alternateCamera.enabled = false;
        hasSwitched = false;
        currentRotation = 0;
    }
}
