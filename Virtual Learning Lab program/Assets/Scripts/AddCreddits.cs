using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class AddCreddits : MonoBehaviour
{
    public Transform contentWindow;
    public GameObject recallTextObject;

    void Start()
    {
        string readFromFilePath = "/Scenes/" + "/Recourses/" + "CREDITS" + ".txt";
    }
}