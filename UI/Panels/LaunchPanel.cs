using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
//using DG.Tweening;
using System.Linq;
//using Photon.Pun;
//using Cysharp.Threading.Tasks;

public class LaunchPanel : BasePanel
{
    #region Inspector
    [SerializeField] private GameObject obj_startGame;
    [SerializeField] private GameObject obj_setting;
    [SerializeField] private GameObject obj_exitGame;

    [SerializeField] private GameObject obj_joinRoom;
    [SerializeField] private GameObject obj_createRoom;
    [SerializeField] private GameObject obj_inputRoomNumber;
    #endregion

    private GameObject[] list_hideGameObjects = new GameObject[3];  
    private GameObject[] list_startGameObjs = new GameObject[3];

    public override void OnEnter() 
    {
        list_hideGameObjects[0] = obj_startGame;
        list_hideGameObjects[1] = obj_setting;
        list_hideGameObjects[2] = obj_exitGame;

        list_startGameObjs[0] = obj_joinRoom;
        list_startGameObjs[1] = obj_createRoom;
        list_startGameObjs[2] = obj_inputRoomNumber;

        obj_startGame.GetOrAddComponent<Button>().onClick.AddListener(OnClickStart);
        obj_createRoom.GetOrAddComponent<Button>().onClick.AddListener(OnClickCreate);
    }

    void OnClickStart() 
    {
        HideButtons();
    }

    void OnClickCreate() 
    {
        //PhotonManager.CreateRoom();
        //UIManager.Instance.OpenPanel(eUIPanelType.LoadingPanel);
    }

    void HideCurrentButtonsByTween() 
    {

    }
    
    private void HideButtons() 
    {
        for (int i = 0; i < list_hideGameObjects.Length; i++)
        {
            //UIManager.tweenHideGameObject(list_hideGameObjects[i], eDirection.LEFT);
        }

        for (int i = 0; i < list_startGameObjs.Length; i++)
        {
            //UIManager.tweenHideGameObject(list_startGameObjs[i], eDirection.LEFT,0);
        }
    }

    private void SelectStart() 
    {
    
    }
}
