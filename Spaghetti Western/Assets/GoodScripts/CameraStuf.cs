using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStuf : MonoBehaviour
{
    public float xSensitivity = 10f;
    public float ySensitivity = 10f;
    float yaw;
    float pitch;
    public Transform playerRotation;
    private Quaternion nextRotation;
    public GameObject followTransform;
    public Gun gun;
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X"); 
        float mouseY = Input.GetAxisRaw("Mouse Y"); 
        followTransform.transform.rotation *= Quaternion.AngleAxis(mouseX * xSensitivity, Vector3.up);
        followTransform.transform.rotation *= Quaternion.AngleAxis(mouseY * ySensitivity, Vector3.right);
        var angles = followTransform.transform.localEulerAngles;
        angles.z = 0;
        var angle = followTransform.transform.localEulerAngles.x;
        if(angle > 180 && angle < 340){
            angles.x = 340;
        } else if(angle < 180 && angle > 40){
            angles.x = 40;
        }
        followTransform.transform.localEulerAngles = angles;
        playerRotation.rotation = Quaternion.Euler(0, followTransform.transform.rotation.eulerAngles.y, 0);
        followTransform.transform.localEulerAngles = new Vector3(angles.x, 0, 0);  
    }
}
