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

        var url = "https://virtual-learninglab.github.io/CREDITS.html";

        var httpClient = new HttpClient();
        var html = httpClient.GetStringAsync(url);

        //Removing all the html code
        string html_results = html.Result.Replace("<!DOCTYPE html>", "").Replace("<html>", "").Replace("</html>", "").Replace("Credits", "").Replace("<title>", "").Replace("</title>", "").Replace("<head>", "").Replace("</head>", "").Replace("<h1>", "").Replace("</h1>", "").Replace("<h2>", "").Replace("</h2>", "").Replace("<h3>", "").Replace("</h3>", "").Replace("<body>", "").Replace("</body>", "");
        //string credits_results = html_results.Replace("\n", "").Replace("!p!", "");
        string credits_results = Regex.Replace(html_results, @"^\s+$[\r\n]*", @"", RegexOptions.Multiline).Replace("!p!", "");

        Debug.Log(credits_results);

        _credits.text = credits_results;

        //For 14 lines of credits (including blanks) we have a y transform from -250 to 600 or a delta y of 400
        //For a delta y of 400 we use 1000 frames of animation
        //So per line we need a transformation of 28.5714285714 and 2.5 frames
        float frames_per_line = 2.5F;
        float transform_per_line = 28.5714285714F;
        animate_text();

        void animate_text()
        {
            _credits.rectTransform(1,1,1);
        }
    }
}
