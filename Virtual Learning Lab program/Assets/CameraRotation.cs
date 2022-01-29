using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private static CameraRotation instance;
    public static CameraRotation Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CameraRotation>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned CameraRotation", typeof(CameraRotation)).GetComponent<CameraRotation>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }

}
