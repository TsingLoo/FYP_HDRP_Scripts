using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyMe : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
