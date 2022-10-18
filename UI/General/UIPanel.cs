using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI����ȫö�٣����������桢������桢���ý��桢��������ȡ�
/// Ϊ�˷���ű����л����˴�����Ӧ�����Ӧ��Ԥ������ͳһ��
/// </summary>
public enum eUIPanelType
{
    MainMenuPanel = 0,
    RoomMenuPanel,
    SettingPanel,
    BagPanel,
    NotesPanel,
    ConfirmPopupPanel,
    LaunchPanel,
    LoadingPanel,
    ChooseCharacterPanel
}

public class UIPanel
{
    public eUIPanelType UIPanelType;
    public string UIPanelPath;

    public override string ToString()
    {
        return( "The eUIPanelType is " + UIPanelType + " UIPanelPath is " + UIPanelPath);
    }
}