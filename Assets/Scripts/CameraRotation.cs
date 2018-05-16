using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    public float rotationSpeed;
    public float pitchClampValue;
    public float yawClampValue;

    float xRotationValue;
    float yRotationValue;
    float zRotationValue;

    Quaternion cameraRotation;
    Transform myCamera;

    private void Start()
    {
        myCamera = Camera.main.transform;
    }

    void Update ()
    {
        xRotationValue += Input.GetAxis("Pitch") * (rotationSpeed * .5f) * Time.deltaTime;
        yRotationValue += Input.GetAxis("Yaw") * (rotationSpeed * .5f) * Time.deltaTime;
        zRotationValue += Input.GetAxis("Roll") * rotationSpeed * Time.deltaTime;

        xRotationValue = ClampAngle(xRotationValue, -pitchClampValue, pitchClampValue);
        yRotationValue = ClampAngle(yRotationValue, -yawClampValue, yawClampValue);

        cameraRotation = Quaternion.Euler(xRotationValue, yRotationValue, zRotationValue);
        myCamera.transform.localRotation = cameraRotation;

    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360.0f)
            angle += 360.0f;
        if (angle > 360.0f)
            angle -= 360.0f;
        return Mathf.Clamp(angle, min, max);
    }
}
