using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSettings : MonoBehaviour
{
    void Start()
    {
        SettingsLoad loadsetting = new SettingsLoad();
        loadsetting.VR = true;

        JsonUtility.FromJson<SettingsLoad>("settings.json");
    }

    private class SettingsLoad
    {
        public bool VR;
    }
}
