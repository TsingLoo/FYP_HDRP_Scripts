using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform mainCameraTransform;

    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
        print(mainCameraTransform.gameObject.name);
    }


    void LateUpdate()//called everyfame after update 
    {
      
        transform.LookAt(mainCameraTransform,Vector3.down);
    }

}