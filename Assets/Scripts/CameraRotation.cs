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

    Vector3 targetRotation;
    Vector3 currentRotation;

    private void Start()
    {
        myCamera = Camera.main.transform;

        targetRotation = Random.rotation.eulerAngles;
        targetRotation.z = 0;
    }

    private void Update()
    {
     //   if(CheckRotation()) //||
     //   {
     //       targetRotation = new Vector3(Random.Range(-pitchClampValue, pitchClampValue), Random.Range(-yawClampValue, yawClampValue), 0);
     //       targetRotation.z = 0;
     ////       print("Target Rotation" + targetRotation);
     //   }

    //    myCamera.transform.Rotate(targetRotation.x * Vector3.right * rotationSpeed * Time.deltaTime);
     //   myCamera.transform.Rotate(targetRotation.y * Vector3.up * rotationSpeed * Time.deltaTime);

    //    myCamera.transform.rotation = Quaternion.Euler(Vector3.Lerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime));

     //   print("Current Rotation" + currentRotation);
        //Move(currentRotation.x, currentRotation.y);

    }

    bool CheckRotation()
    {
        if (Mathf.Abs(myCamera.transform.rotation.x - targetRotation.x) < .1f)
        {
            if (Mathf.Abs(myCamera.transform.rotation.y - targetRotation.y) < .1f)
            {
                return true;
            }
            else return false;
        }
        else
            return false;
    }

    void Move (float moveX, float moveY)
    {
      //  xRotationValue += moveX * rotationSpeed * Time.deltaTime;
      //  yRotationValue += moveY * rotationSpeed * Time.deltaTime;
       // zRotationValue += Input.GetAxis("Roll") * rotationSpeed * Time.deltaTime;

        xRotationValue = ClampAngle(moveX, -pitchClampValue, pitchClampValue);
        yRotationValue = ClampAngle(moveY, -yawClampValue, yawClampValue);

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
