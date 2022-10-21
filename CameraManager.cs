using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using taecg.tools.ImageExporter;
using UnityEngine;

public class CameraManager : SingletonForMonobehaviour<CameraManager>
{ 
    [SerializeField] GameObject CameraPrefab_Normal;
    [SerializeField] Transform center;


    public void PlaceCamera(int CameraPlaceType) 
    {

        int nums = PlayerPrefs.GetInt(SaveDataManager.CAMERA_NUM);
        float height = PlayerPrefs.GetFloat(SaveDataManager.CAMERA_HEIGHT);

        Debug.Log("[CameraManager]nums:" + nums.ToString()+" height:" + height.ToString() );

        switch (CameraPlaceType)
        {
            case (int)ConfigPanel.eCameraGenerateMethod.Ellipse:
                Utils.PlaceObjByEllipse(CameraPrefab_Normal, center,nums,PlayerPrefs.GetFloat(SaveDataManager.ELLIPSE_MAJORAXIS),PlayerPrefs.GetFloat(SaveDataManager.ELLIPSE_MINORAXIS),height);

                break;
            default:
                Debug.LogWarning("NO TARGET CASE");
                break;
        
        }
                

    }

    



}
