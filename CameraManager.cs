using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject CameraPrefab_Normal;
    [SerializeField] Transform center;

    [SerializeField][Range(0, 20)] float Ellipse_a;
    [SerializeField][Range(0, 20)] float Ellipse_b;


    private void Awake()
    {
        Utils.PlaceObjByEllipse(CameraPrefab_Normal,center, 12,Ellipse_a,Ellipse_b);
    }

    



}
