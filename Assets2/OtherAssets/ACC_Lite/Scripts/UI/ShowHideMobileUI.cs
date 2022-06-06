using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideMobileUI : MonoBehaviour
{
    [SerializeField] GameObject MobileUI;
    [SerializeField] GameObject PcConcoleUI;

    public static bool IsMobilePlatform
    {
        get
        {
#if UNITY_EDITOR

            return UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.Android ||
                UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.iOS;
#else
                return Application.isMobilePlatform;
#endif
        }
    }

    void Start()
    {
        MobileUI.SetActive (IsMobilePlatform);
        PcConcoleUI.SetActive (!IsMobilePlatform);
    }
}
