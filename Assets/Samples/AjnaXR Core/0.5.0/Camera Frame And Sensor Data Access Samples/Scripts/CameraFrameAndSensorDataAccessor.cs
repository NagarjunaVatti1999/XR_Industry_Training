using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraFrameAndSensorDataAccessor : MonoBehaviour
{

    [Header("Camera Frames")]
    [SerializeField] private RawImage rawImage;

    [Header("Camera Intrinsics")]
    [SerializeField] private AXRCameraFramesAndSensorIntrinsics sensorIntrinsicsScript;

    [SerializeField] TextMeshProUGUI resolutionText;

    [SerializeField] TextMeshProUGUI focalLengthText;

    [SerializeField] TextMeshProUGUI principalPointText;

    private void OnEnable() {
        AXRCameraFramesAndSensorIntrinsics.CameraTextureProcessedAndReady += UpdateRawImageTexture;
    }

    private void Start() {
        // A 0.15f delay is necessary to ensure all camera settings are configured correctly, allowing this script to receive accurate values
        Invoke(nameof(UpdateSensorDataUI), 0.15f);
    }

    private void OnDisable() {
        AXRCameraFramesAndSensorIntrinsics.CameraTextureProcessedAndReady -= UpdateRawImageTexture;
    }


    private void UpdateRawImageTexture(Texture2D latestTexture) {
        rawImage.texture = latestTexture;
    }

    private void UpdateSensorDataUI() {

        if (sensorIntrinsicsScript) {
            if(resolutionText)
                resolutionText.text = $"RESOLUTION - W : {sensorIntrinsicsScript.Resolution.x}, H : {sensorIntrinsicsScript.Resolution.y}";
            if(focalLengthText)
                focalLengthText.text = $"FOCAL LENGTH - X : {sensorIntrinsicsScript.FocalLength.x:#0.00}, Y : {sensorIntrinsicsScript.FocalLength.y:#0.00}";
            if(principalPointText)
                principalPointText.text = $"PRINCIPAL POINT - X : {sensorIntrinsicsScript.PrincipalPoint.x:#0.00}, Y : {sensorIntrinsicsScript.PrincipalPoint.y:#0.00}";
        } else {
            Debug.LogError("Ensure the AXRRetrievingSensorIntrinsics script is attached in the inspector.");
        }

    }

} // class