using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        UIManager.Instance.UIPanelInfoSaveInJson();
        UIManager.Instance.OpenPanel(eUIPanelType.LaunchPanel);

    }
}
