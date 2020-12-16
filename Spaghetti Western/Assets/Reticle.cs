using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
    private RectTransform reticle;
    public float restingSize;
    public float maxSize;
    public float aimSize;
    public float speed;
    private float currentSize;
    public Gun gun;

    private void Start(){
        reticle = GetComponent<RectTransform>();
    }
    private void Update(){
        if(isMoving && !gun.isAiming){
            currentSize = Mathf.Lerp(currentSize, maxSize, Time.deltaTime * speed);
        } else if(!isMoving && !gun.isAiming) {
            currentSize = Mathf.Lerp(currentSize, restingSize, Time.deltaTime * speed);
        }
        if(gun.isAiming){
            currentSize = Mathf.Lerp(currentSize, aimSize, Time.deltaTime * speed);
        }

        reticle.sizeDelta = new Vector2(currentSize, currentSize);
    }
    bool isMoving{
        get {
            if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                return true;
            else
                return false;
        }
    }
}
