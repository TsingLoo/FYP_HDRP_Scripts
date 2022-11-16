using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
   

    private void Start()
    { 
        

        DontDestroyOnLoad(gameObject);

        UIManager.Instance.UIPanelInfoSaveInJson();
        UIManager.Instance.OpenPanel(eUIPanelType.LaunchPanel);

        SceneManager.sceneLoaded += SceneLoadedHandler;
        //Debug.Log(PlayerPrefs.GetString("Maweasda",null))

        DirectoryInfo Image_subsets = new DirectoryInfo(CameraManager.Image_subsets);
        if (Image_subsets.Exists)
        {
            Image_subsets.Delete(true);
            Debug.Log("[IO]" + Image_subsets.ToString() + " have been deleted");
        }

        DirectoryInfo matchings = new DirectoryInfo(CameraManager.matchings);
        if (matchings.Exists)
        {
            matchings.Delete(true);
            Debug.Log("[IO]" + matchings.ToString() + " have been deleted");
        }

        Directory.CreateDirectory(CameraManager.matchings);
        Debug.Log("[IO]文件夹" + CameraManager.matchings + "创建成功");
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
