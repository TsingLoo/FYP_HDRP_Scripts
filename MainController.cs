using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : SingletonForMonobehaviour<MainController>
{

    public string parentFolder;
    [HideInInspector]   public string Image_subsets;
    [HideInInspector]   public string matchings;

    private void Awake()
    {
        Image_subsets = MainController.Instance.parentFolder + @"\Image_subsets";
        matchings = MainController.Instance.parentFolder + @"\matchings";
    }

    private void Start()
    { 
        

        DontDestroyOnLoad(gameObject);

        UIManager.Instance.UIPanelInfoSaveInJson();
        UIManager.Instance.OpenPanel(eUIPanelType.LaunchPanel);

        SceneManager.sceneLoaded += SceneLoadedHandler;
        //Debug.Log(PlayerPrefs.GetString("Maweasda",null))

        DirectoryInfo dir_image_subsets = new DirectoryInfo(Image_subsets);
        if (dir_image_subsets.Exists)
        {
            dir_image_subsets.Delete(true);
            Debug.Log("[IO]" + Image_subsets.ToString() + " have been deleted");
        }

        DirectoryInfo dir_matchings = new DirectoryInfo(matchings);

        if (dir_matchings.Exists)
        {
            dir_matchings.Delete(true);
            Debug.Log("[IO]" + matchings.ToString() + " have been deleted");
        }

        Directory.CreateDirectory(matchings);
        Debug.Log("[IO]文件夹" + matchings + "创建成功");
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
