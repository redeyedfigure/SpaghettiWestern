using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioSource gunSound;
    public Cinemachine.CinemachineImpulseSource source;
    public GameObject mainCamera;
    public GameObject aimCamera;
    public bool isAiming = false;
    public Transform cam;
    public float weaponRange;
    public float damage;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && isAiming){
            gunSound.Play();
            source.GenerateImpulse(Camera.main.transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(cam.position, cam.forward, out hit, weaponRange)){
                Debug.Log("Hit");
                Target target = hit.transform.GetComponent<Target>();
                if(target != null){
                    target.Hit(damage);
                }
            } else {
                Debug.Log("Miss");
            }
        } else if(Input.GetMouseButtonDown(0) && !isAiming){
            Debug.Log("Melee");
        }
        if(Input.GetMouseButton(1) && !aimCamera.activeInHierarchy){
            isAiming = true;
            mainCamera.SetActive(false);
            aimCamera.SetActive(true);
        } else if(!Input.GetMouseButton(1) && !mainCamera.activeInHierarchy){
            isAiming = false;
            mainCamera.SetActive(true);
            aimCamera.SetActive(false);
        }
    }
}
