using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI面板的全枚举，例如主界面、房间界面、设置界面、背包界面等。
/// 为了方便脚本序列化，此处名称应当与对应的预制体相统一。
/// </summary>
public enum eUIPanelType
{
    BasePanel = 0,
    SettingPanel,
    ConfirmPopupPanel,
    LaunchPanel,
    LoadingPanel,
    ChooseBluePrintPanel,
    BoomViewPanel
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
