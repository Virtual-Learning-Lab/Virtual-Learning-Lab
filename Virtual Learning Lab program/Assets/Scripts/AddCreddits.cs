using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AddCreddits : MonoBehaviour
{
    //public Transform contentWindow;
    //public GameObject recallTextObject;
    [SerializeField]
    private TMP_Text _credits;

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
        string html_results = html.Result.Replace("<!DOCTYPE html>", "").Replace("<html>", "").Replace("</html>", "").Replace("Credits", "").Replace("<title>", "").Replace("</title>", "").Replace("<head>", "").Replace("</head>", "").Replace("<h1>", "").Replace("</h1>", "").Replace("<h2>", "").Replace("</h2>", "").Replace("<h3>", "").Replace("</h3>", "").Replace("<body>", "").Replace("</body>", "");
        string credits_results = html_results.Replace("\n", "").Replace("!p!", "\n").Replace("  ", "\n");

        Debug.Log(credits_results);

        _credits.text = credits_results;
    }
}
