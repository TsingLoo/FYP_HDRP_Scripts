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
        //Debug.Log(PlayerPrefs.GetString("Maweasda",null));

    }

    private void bandMatrix(int n, int width)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (j + 1 < width)
                {
                    Debug.Log("*");
                    Debug.Log("  ");
                }
                else 
                {
                    Debug.Log("0");
                }
            }
        }
    }
}
