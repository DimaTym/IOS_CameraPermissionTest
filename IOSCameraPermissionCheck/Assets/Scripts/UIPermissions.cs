using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPermissions : MonoBehaviour
{
    public Text m_TextLog;

    public void RequestPermission()
    {
        IOSCameraPermissionController.CreateOrGetInstance().RequestPermissionForCamera(RequestPermissionResult);
    }
    
    void RequestPermissionResult(bool result)
    {
        m_TextLog.text += $"\n request result is: {result}";
    }
    
    public void CheckPermission()
    {
        m_TextLog.text += $"\n check result is: {IOSCameraPermissionController.HasUserCameraAuthorization}";
    }


    public void OpenSettings()
    {
        IOSPermissionSettings.OpenSettings();
    }
}
