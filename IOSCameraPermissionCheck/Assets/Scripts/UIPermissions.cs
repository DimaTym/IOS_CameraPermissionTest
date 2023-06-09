//Some links
// iOS docs - https://developer.apple.com/documentation/uikit/uiapplication/1623042-opensettingsurlstring
// Great forum - https://forum.unity.com/threads/request-and-get-state-of-camera-permission.281858/
// Github from forum - https://github.com/CoryButler/Unity_iOSCameraPermission
// IDea for check plugin - https://www.appsloveworld.com/coding/ios/2/detect-permission-of-camera-in-ios


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPermissions : MonoBehaviour
{
    public Text m_TextLog;


    private void OnEnable()
    {
        Application.logMessageReceived += LogCallback;
    }
    
    //Called when there is an exception
    void LogCallback(string condition, string stackTrace, LogType type)
    {
        m_TextLog.text += $"\n {type}: {condition}";
    }

    void OnDisable()
    {
        Application.logMessageReceived -= LogCallback;
    }

    public void RequestPermission()
    {
        IOSCameraPermissionController.CreateOrGetInstance().RequestPermissionForCamera(RequestPermissionResult);
    }
    
    void RequestPermissionResult(bool result)
    {
        Debug.Log($"request result is: {result}");
        //m_TextLog.text += $"\n request result is: {result}";
    }
    
    public void CheckPermission()
    {
        Debug.Log($"check result is: {IOSCameraPermissionController.HasUserCameraAuthorization}");
        //m_TextLog.text += $"\n check result is: {IOSCameraPermissionController.HasUserCameraAuthorization}";
    }


    public void OpenSettings()
    {
        IOSPermissionSettings.OpenSettings();
    }
}
