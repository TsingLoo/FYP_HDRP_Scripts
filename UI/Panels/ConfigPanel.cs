using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using System;
using UnityEngine.UI;
using UnityEditor.Search;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class ConfigPanel : BasePanel
{
    #region CameraGenerateMehod
    [Header("CameraGenerateMethod")]
    [SerializeField] TMP_Dropdown dpd_CameraGenerateMethod;
    [SerializeField] TMP_InputField input_Nums;
    [SerializeField] TMP_InputField input_Height;

    [Header("Ellipse_Params")]
    [SerializeField] GameObject obj_Ellipse_Params;
    [SerializeField] TMP_InputField input_Ellipse_MajorAxis;
    [SerializeField] TMP_InputField input_Ellipse_MinorAxis;

    [Header("Square_Params")]
    [SerializeField] GameObject obj_Square_Params;
    [SerializeField] TMP_InputField input_Square_LongEdge;
    [SerializeField] TMP_InputField input_Square_ShortEdge;

    [Header("Preset_Params")]
    [SerializeField] GameObject obj_Preset_Params;
    public enum eCameraGenerateMethod
    {
        Ellipse = 0,
        Square = 1,
        Preset = 2
    }

    private void InitCameraGenerateMethod()
    {
        UtilExtension.InputIntAndSave(input_Nums, SaveDataManager.CAMERA_NUM);
        UtilExtension.InputFloatAndSave(input_Height, SaveDataManager.CAMERA_HEIGHT, 2.8f);

        Utils.InitTMPDropDownByEnum(typeof(eCameraGenerateMethod), dpd_CameraGenerateMethod);
        dpd_CameraGenerateMethod.onValueChanged.AddListener(dpd_CameraGenerateMethod_Handler);

        //Default Select Ellipse Method
        dpd_CameraGenerateMethod_Handler(0);

    }

    private void dpd_CameraGenerateMethod_Handler(int index)
    {
        PlayerPrefs.SetInt(SaveDataManager.CAMERA_GENERATE_TYPE, index);
        PlayerPrefs.Save();
        switch (index)
        {
            case (int)eCameraGenerateMethod.Ellipse:
                UtilExtension.SafeSetActive(obj_Ellipse_Params, true);
                UtilExtension.SafeSetActive(obj_Square_Params, false);
                UtilExtension.SafeSetActive(obj_Preset_Params, false);
                UtilExtension.InputFloatAndSave(input_Ellipse_MajorAxis, SaveDataManager.ELLIPSE_MAJORAXIS);
                UtilExtension.InputFloatAndSave(input_Ellipse_MinorAxis, SaveDataManager.ELLIPSE_MINORAXIS);
                break;
            case (int)eCameraGenerateMethod.Square:
                UtilExtension.SafeSetActive(obj_Ellipse_Params, false);
                UtilExtension.SafeSetActive(obj_Square_Params, true);
                UtilExtension.SafeSetActive(obj_Preset_Params, false);
                UtilExtension.InputFloatAndSave(input_Square_LongEdge, SaveDataManager.SQUARE_LONGEDGE);
                UtilExtension.InputFloatAndSave(input_Square_ShortEdge, SaveDataManager.SQUARE_SHORTEDGE);
                break;
            case (int)eCameraGenerateMethod.Preset:
                UtilExtension.SafeSetActive(obj_Ellipse_Params, false);
                UtilExtension.SafeSetActive(obj_Square_Params, false);
                UtilExtension.SafeSetActive(obj_Preset_Params, true);
                break;
            default:
                Debug.LogWarning("NO TARGET CASE");
                break;
        }
    }


    #endregion

    #region FramesSettings
    [Header("FrameSettings")]
    [SerializeField] TMP_Dropdown dpd_FramesSettings;
    public enum eFramesSettings
    {
        GivenFrameCount = 0,
        TriggerByKey = 1,
    }

    private void InitFramesSettings()
    {
        Utils.InitTMPDropDownByEnum(typeof(eFramesSettings), dpd_FramesSettings);
        InitGivenFrameCount();
    }


    #region Given_FrameCount
    [Header("Given_FrameCount")]
    [SerializeField] TMP_InputField input_StartFrame;
    [SerializeField] TMP_InputField input_EndFrame;
    [SerializeField] TMP_InputField input_FrameCount;

    private void InitGivenFrameCount() 
    {
        UtilExtension.InputIntAndSave(input_StartFrame, SaveDataManager.START_FRAME);
        UtilExtension.InputIntAndSave(input_EndFrame, SaveDataManager.END_FRAME);
        UtilExtension.InputIntAndSave(input_FrameCount, SaveDataManager.FRAME_COUNT);

        input_EndFrame.onEndEdit.AddListener(CalculateFrameCount);
        input_FrameCount.onEndEdit.AddListener(CalculateEndFrame);

        input_StartFrame.onEndEdit.AddListener(CalculateFrameCount);
        input_StartFrame.onEndEdit.AddListener(CalculateEndFrame);
    }

    private void CalculateFrameCount(string value)
    {

        input_FrameCount.text = (int.Parse(input_EndFrame.text) - int.Parse(input_StartFrame.text)).ToString();
        PlayerPrefs.SetInt(SaveDataManager.FRAME_COUNT,int.Parse(input_FrameCount.text));
    }

    private void CalculateEndFrame(string value)
    {

        input_EndFrame.text = (int.Parse(input_FrameCount.text) + int.Parse(input_StartFrame.text)).ToString();
        PlayerPrefs.SetInt(SaveDataManager.END_FRAME, int.Parse(input_EndFrame.text));
    }
    #endregion

    #endregion

    #region QualitySettings
    private void InitQualitySetting()
    {
        Vector2 resolution = new Vector2(1920,1080);
      
    }
    #endregion

    #region PanelUI
    [Header("Next_Button")]
    [SerializeField] GameObject obj_NextButton;
    Button btn_Next;

    public override void OnEnter()
    {
        InitCameraGenerateMethod();
        InitFramesSettings();
        btn_Next = obj_NextButton.GetOrAddComponent<Button>();
        btn_Next.onClick.AddListener(ClickNextButtonHandler);
    }

    private void ClickNextButtonHandler() 
    {
        UIManager.Instance.PopPanel();
        UIManager.Instance.OpenPanel(eUIPanelType.LoadingPanel);
        PlayerPrefs.Save();

        SceneManager.LoadScene(1);

    }

    private bool CanNext() 
    {
        return false;
    }
    #endregion
}
