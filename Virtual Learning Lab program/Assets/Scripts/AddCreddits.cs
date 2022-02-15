using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

public class AddCreddits : MonoBehaviour
{
    public Transform contentWindow;
    public GameObject recallTextObject;

    void Start()
    {
        //Get all CREDITS information from CREDTIS.html which is a page on the official Virtual Learning lab website
        var url = "https://virtual-learninglab.github.io/CREDITS.html"        
    }
}
