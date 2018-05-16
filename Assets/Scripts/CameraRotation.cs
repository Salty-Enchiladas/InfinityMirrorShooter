using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    public float rotationSpeed;
	
	void Update () {
        transform.Rotate(Vector3.forward * Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
	}
}
