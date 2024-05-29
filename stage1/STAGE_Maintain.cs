using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STAGE_Maintain : MonoBehaviour
{
    public static STAGE_Maintain Instance;
    public string sceneNow;

    //public Color TeamColor;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
