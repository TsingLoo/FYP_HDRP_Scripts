using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
//using DG.Tweening;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
//using Photon.Pun;
//using Cysharp.Threading.Tasks;

public class LaunchPanel : BasePanel
{
    #region Inspector
    [SerializeField] private GameObject obj_startGame;
    [SerializeField] private GameObject obj_setting;
    [SerializeField] private GameObject obj_exitGame;
    #endregion

    public override void OnEnter() 
    {
        obj_startGame.GetOrAddComponent<Button>().onClick.AddListener(OnClickStart);
        obj_setting.GetOrAddComponent<Button>().onClick.AddListener(OnClickSetting);
        obj_exitGame.GetOrAddComponent<Button>().onClick.AddListener(OnClickExit);
    }

    void OnClickStart() 
    {
        UIManager.Instance.PopPanel();
        UIManager.Instance.OpenPanel(eUIPanelType.ConfigPanel);
    }

    void OnClickSetting() 
    {
       
    }

    void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void HideCurrentButtonsByTween() 
    {

    }
    
    private void HideButtons() 
    {

    }

    private void SelectStart() 
    {
    
    }
}
