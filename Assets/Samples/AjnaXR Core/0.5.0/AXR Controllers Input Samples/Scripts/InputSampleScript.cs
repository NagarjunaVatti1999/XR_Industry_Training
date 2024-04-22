using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class InputSampleScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI rightControllerPose;
    [SerializeField]
    TextMeshProUGUI leftControllerPose;
    [SerializeField]
    TextMeshProUGUI rightControllerTrackingStatus;
    [SerializeField]
    TextMeshProUGUI leftControllerTrackingStatus;


    public void DisplayLeftControllerPose(InputAction.CallbackContext value)
    {
        leftControllerPose.text = value.ReadValue<Vector3>().ToString();
        leftControllerTrackingStatus.text = $"{AXRControllerInput.AXRLeftControllerTrackingStatus}";
    }

    public void DisplayRightControllerPose(InputAction.CallbackContext value) {
        rightControllerPose.text = value.ReadValue<Vector3>().ToString();
        rightControllerTrackingStatus.text = $"{AXRControllerInput.AXRRightControllerTrackingStatus}";
    }

}
