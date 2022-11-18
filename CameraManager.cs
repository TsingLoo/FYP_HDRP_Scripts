using FlyingWormConsole3.LiteNetLib;
using Jumpy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using taecg.tools.ImageExporter;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class CameraManager : SingletonForMonobehaviour<CameraManager>
{
    public const int RESOLUTION_WIDTH = 1920;
    public const int RESOLUTION_HEIGHT = 1080;

    //public string parentFolder;


    public enum eFileExtention
    {
        png,
        jpg
    }
    public eFileExtention ImageFormat = eFileExtention.jpg;


    private GameObject CameraPrefab_Normal;
    [SerializeField] Transform center;

    public UnityAction<string> ExportThisFrame;
    public UnityAction EndExport;
    
    public int BeginFrameCount; 
    public int EndFrameCount;

    public void PlaceCamera(int CameraPlaceType) 
    {
        int nums = PlayerPrefs.GetInt(SaveDataManager.CAMERA_NUM);
        float height = PlayerPrefs.GetFloat(SaveDataManager.CAMERA_HEIGHT);

        Debug.Log("[CameraManager]nums:" + nums.ToString()+" height:" + height.ToString() );

        switch (CameraPlaceType)
        {
            case (int)ConfigPanel.eCameraGenerateMethod.Ellipse:
                Debug.Log("[Debug]" + CameraPrefab_Normal.ToString());
                Utils.PlaceObjByEllipse(CameraPrefab_Normal, center,nums,PlayerPrefs.GetFloat(SaveDataManager.ELLIPSE_MAJORAXIS),PlayerPrefs.GetFloat(SaveDataManager.ELLIPSE_MINORAXIS),height);

                break;
            default:
                Debug.LogWarning("NO TARGET CASE");
                break;
        
        }
    }

    private void Awake()
    {
        Debug.Log("[Debug] CamraManager init");
        BeginFrameCount = PlayerPrefs.GetInt(SaveDataManager.START_FRAME) + Time.frameCount;
        EndFrameCount = PlayerPrefs.GetInt(SaveDataManager.END_FRAME)+ Time.frameCount;

        CameraPrefab_Normal = PrefabsLoader.Instance.camera_normal;


    }

    public void FramesSetting(int FramesSettingType) 
    {
        switch (FramesSettingType)
        {
            case (int)ConfigPanel.eFramesSettings.GivenFrameCount:
                BeginFrameCount = PlayerPrefs.GetInt(SaveDataManager.START_FRAME);
                EndFrameCount = PlayerPrefs.GetInt(SaveDataManager.END_FRAME);
                break;
            default:
                Debug.LogWarning("NO TARGET CASE");
                break;

        }
    }

    void Update()
    {
        Debug.Log("[IO]FrameCount " + Time.frameCount + " " + BeginFrameCount + "  " + EndFrameCount);
        if (Time.frameCount >= BeginFrameCount && Time.frameCount <= EndFrameCount)
        {
            
            Debug.Log("[IO]FrameCount " + Time.frameCount);
            ExportThisFrame?.Invoke("." + ImageFormat.ToString());
        }
        else if (Time.frameCount > EndFrameCount)
        {
            EndExport?.Invoke();
        }

     

        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    BeginToExport?.Invoke("." + ImageFormat.ToString());
        //}
    }

    private void InvokeBeginToExport() 
    {
        //if(Time.frameCount == S)
    }





}
