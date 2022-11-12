using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FaceCamera : MonoBehaviour
{
    private Transform mainCameraTransform;
    public bool isOn = true;
    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
        //print(mainCameraTransform.gameObject.name);
    }


    void LateUpdate()
    {
        if (!isOn) return;
        transform.LookAt(mainCameraTransform,Vector3.down);
    }

}