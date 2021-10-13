using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Text Anzeige;
    public static int nummer;
    // Start is called before the first frame update
    void Start()
    {
        nummer = 0;
    }

    void Update()
    {        
        if (nummer != 69)
        {
            Anzeige.text = nummer.ToString() + " / 7 Teile gesammelt";
        }
        else
        {
            Anzeige.text = " ";
        }
    }

}
