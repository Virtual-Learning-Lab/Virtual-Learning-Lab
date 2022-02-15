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
        /*<!DOCTYPE html>
        <html>
        <head>
        <title>Credits</title>
        </head>
        <body>
            <h1>Credits</h1>
            <h2>Founder</h2>
            <h3>Stephen van Erkelens</h3>
        </body>*/

        var url = "https://virtual-learninglab.github.io/CREDITS.html";
        
        var httpClient = new HttpClient();
        var html = httpClient.GetStringAsync(url);

        //Removing all the html code
        string html_results = html.Result.Replace("<!DOCTYPE html>", "").Replace("<html>", "").Replace("</html>", "").Replace("Credits", "").Replace("<title>", "").Replace("</title>", "").Replace("<head>", "").Replace("</head>", "").Replace("<h1>", "").Replace("</h1>", "").Replace("<h2>", "").Replace("</h2>", "").Replace("<h3>", "").Replace("</h3>", "").Replace("<body>", "").Replace("</body>", "").Replace("!p!", "\n");

        Debug.Log(html_results);
    }
}
