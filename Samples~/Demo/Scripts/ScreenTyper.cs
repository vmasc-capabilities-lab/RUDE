using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenTyper : MonoBehaviour
{
    public enum ScreenType  //To be developed later for making a dynamic sized grid
    {
        Line,
        Grid
    }
    public ScreenType screenType;
    public int fontSize;

    public TMP_Text[] textLines;
    public float typeLimit;
    public GameObject Blink;

    private string textToAdd = "";
    private float typeCounter;
    private bool start = true;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (textToAdd != "")
        {
            typeCounter += Time.deltaTime;
            if (typeCounter > typeLimit)
            {
                textLines[0].text += textToAdd[0];
                if (textToAdd.Length > 0)
                {
                    textToAdd = textToAdd.Substring(1);
                }
                else
                {
                    textToAdd = "";
                }
                typeCounter = 0;
            }
        }
    }

    public void AddText(string newText)
    {
        if (start)  //Remove animated character once text will be added
        {
            Destroy(Blink);
            start = false;
        }

        if (textToAdd != "")    //If user presses button before remaining characters added, quickly add remaining to string
        {
            textLines[0].text += textToAdd;
        }

        for (int i = textLines.Length-1; i > 0; i--){
            textLines[i].text = textLines[i-1].text;
        }
        textLines[0].text = "";
        textToAdd = CleanText(newText);
    }

    private string CleanText(string newText)    //Remove whitespace & makes sure under 35 characters
    {
        string cleanText = newText.Trim();

        if (cleanText.Length > 35)
        {
            cleanText = cleanText.Substring(0, 34);
            cleanText += "...";
        }

        return cleanText;
    }
}
