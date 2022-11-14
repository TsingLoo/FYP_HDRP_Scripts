using Jumpy;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using taecg.tools.ImageExporter;
using UnityEngine;
using UnityEngine.Events;

public class CameraManager : SingletonForMonobehaviour<CameraManager>
{ 
    [SerializeField] GameObject CameraPrefab_Normal;
    [SerializeField] Transform center;

    private UnityAction BeginToExport;
    private int BeginFrameCount; 

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

    public void FramesSetting(int FramesSettingType) 
    {
        switch (FramesSettingType)
        {
            case (int)ConfigPanel.eFramesSettings.GivenFrameCount:
                BeginFrameCount = PlayerPrefs.GetInt(SaveDataManager.START_FRAME);
                break;
            default:
                Debug.LogWarning("NO TARGET CASE");
                break;

        }
    }

    private void Update()
    {
        
    }

    private void InvokeBeginToExport() 
    {
        //if(Time.frameCount == S)
    }





}
