using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ChooseBluePrintPanel : BasePanel
{
    #region Inspector
    [SerializeField] GameObject obj_PartView;
    [SerializeField] GameObject obj_Physical;

    [SerializeField] GameObject obj_Reset;

    //[SerializeField] GameObject obj_Restart;

    [SerializeField] Sprite ConfirmRestatSprite;
    #endregion

    Button btn_PartView;
    Button btn_About;

    Button btn_Reset;

    //Button btn_Restart;
    //Toggle ConfirmRestart;

    //Sprite rawConfirmBtnSprite;

    private void Awake()
    {
        btn_PartView = obj_PartView.GetComponent<Button>();
        btn_About = obj_Physical.GetComponent<Button>();
        btn_Reset = obj_Reset.GetComponent<Button>();

       // btn_Restart = obj_Restart.GetComponentInChildren<Button>();
        //rawConfirmBtnSprite = btn_Restart.GetComponent<Image>().sprite;
        //ConfirmRestart = obj_Restart.GetComponentInChildren<Toggle>();

       // ConfirmRestart.onValueChanged.AddListener(OnComfirmRestart);

        btn_Reset.onClick.AddListener(OnPartViewBtnClick);
        btn_About.onClick.AddListener(OnPhysicalBtnClick);
        btn_Reset.onClick.AddListener(OnResetBtnClick);
        //btn_Restart.onClick.AddListener(OnRestartClick);

        Blueprint.AssemblyIndexChanged += AssemblyIndexChangedHandler;
        DragManager.Instance.beginToAssembly += beginToAssemblyHandler;

        if (MainController.currentAssemblyIndex == -1)
        {
            obj_Reset.SetActive(false);
        }

        obj_Reset.SetActive(false);
        obj_Physical.SetActive(false);
        obj_PartView.SetActive(false);
    }

    void OnPartViewBtnClick()
    {

    }

    void OnPhysicalBtnClick()
    {

    }

    void OnResetBtnClick()
    {
        Blueprint.Instance.LoadCurrentAssembly();
    }

    void OnRestartClick() 
    {
        //if (!ConfirmRestart.isOn) return;

        UIManager.Instance.PopPanel();
        MainController.Instance.Reset();
        Blueprint.Instance.Reset();
        UIManager.Instance.OpenPanel(eUIPanelType.LaunchPanel);
    }

    void AssemblyIndexChangedHandler()
    {
        obj_Reset.SetActive(false);
    }

    void beginToAssemblyHandler()
    {
        obj_Reset.SetActive(true);
    }

    void OnComfirmRestart(bool isOn) 
    {
        if (isOn)
        {
            //btn_Restart.GetComponent<Image>().sprite = ConfirmRestatSprite;
        }
        else 
        {
            //btn_Restart.GetComponent<Image>().sprite = rawConfirmBtnSprite;
        }
    }

}
