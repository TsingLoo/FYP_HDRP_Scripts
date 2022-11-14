using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public const int RESOLUTION_WIDTH = 1920;
    public const int RESOLUTION_HEIGHT = 1080;

    private void Start()
    { 
        

        DontDestroyOnLoad(gameObject);

        UIManager.Instance.UIPanelInfoSaveInJson();
        UIManager.Instance.OpenPanel(eUIPanelType.LaunchPanel);

        SceneManager.sceneLoaded += SceneLoadedHandler;
        //Debug.Log(PlayerPrefs.GetString("Maweasda",null))
    }

    private void SceneLoadedHandler(Scene currentScene,LoadSceneMode loadSceneMode) 
    {
        UIManager.Instance.PopPanel();

        Debug.Log("[Scene]Scene " + currentScene.buildIndex + " loaded successfully");

        if (currentScene.buildIndex == 1) 
        {
            CameraManager.Instance.PlaceCamera(PlayerPrefs.GetInt(SaveDataManager.CAMERA_GENERATE_TYPE));
        }
    }

}
