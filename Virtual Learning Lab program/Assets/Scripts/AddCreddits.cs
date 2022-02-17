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


//original animation: frame 0, position y-250; frame 1000, position y650


public class AddCreddits : MonoBehaviour
{
    //public Transform contentWindow;
    //public GameObject recallTextObject;
    [SerializeField]
    private TMP_Text _credits;
    public GameObject credits_position;
    public int credits_num_lines;
    public float frames_per_transform;
    public float transform_per_line;
    public float start_pos;
    public float end_pos;
    public float iterations;
    public float iterations_had = 0;
    public float y_update;
    public float current_pos;

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
        credits_num_lines = credits_results.Split('\n').Length-1;
        Debug.Log(credits_num_lines);

        //For 14 lines of credits (including blanks) we have a y transform from -250 to 600 or a delta y of 400
        //For a delta y of 400 we use 1000 frames of animation
        //So per line we need a transformation of 28.5714285714 and 2.5 frames
        frames_per_transform = 2.5F;
        transform_per_line = 25; //28.5714285714F;
        start_pos = 200;
        end_pos = credits_num_lines * transform_per_line;
        float iterations_y_update = ((start_pos + end_pos) + (frames_per_transform * transform_per_line))*6;
        y_update = ((start_pos + end_pos) / iterations_y_update)-0.01F;
        iterations = ((start_pos + end_pos) + (frames_per_transform * transform_per_line))*13;
        current_pos = start_pos;
        Debug.Log(iterations);
        //Debug.Log(y_update);
    }

    void Update()
    { 
        if (iterations_had >= iterations)
        {
            current_pos = start_pos;
            iterations_had = 0;
        }
        credits_position.transform.position = new Vector3(50, current_pos, 0);
        current_pos += y_update;
        iterations_had += 1;
    }
}
