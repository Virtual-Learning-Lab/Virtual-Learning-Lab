using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using UnityEngine;
using UnityEngine.UI;


public class AddCreddits : MonoBehaviour
{
    public Transform contentWindow;
    public GameObject recallTextObject;

    void Start()
    {
        //Get all CREDITS information from CREDTIS.html which is a page on the official Virtual Learning lab website
        var url = "https://virtual-learninglab.github.io/CREDITS.html";
        
        var httpClient = new HttpClient();
        var html = httpClient.GetStringAsync(url);
        string html_results = html.Result.Replace("<!DOCTYPE html>", "").Replace("<html>", "").Replace("</html>", "");

        Debug.Log(html_results);
    }
}
