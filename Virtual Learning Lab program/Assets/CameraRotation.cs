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

    [Header("Logic")]
    private Gyroscope gyro;
    private Quaternion rotation;
    private bool gyroActive;

    public void EnableGyro()
    {
        if (gyroActive)
        {
            return;
        }

        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }

        gyroActive = gyro.enabled;
    }
    private void Update()
    {
        if (gyroActive)
        {
            rotation = gyro.attitude;
            Debug.Log(rotation);
        }
    }
    public Quaternion GetGyroRotation()
    {
        return rotation;
    }

}
