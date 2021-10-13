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
        Anzeige.text = nummer.ToString() + " / 7 Teile gesammelt";
    }

}
