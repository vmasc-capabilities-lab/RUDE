using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenGrid : MonoBehaviour
{
    public TMP_Text[] editorLines1 = new TMP_Text[5];
    public TMP_Text[] editorLines2 = new TMP_Text[5];
    public TMP_Text[] editorLines3 = new TMP_Text[5];

    public float typeLimit;
    public GameObject Blink;

    private string[] textToAdd = new string[3];
    private float typeCounter;
    private bool start = true;
    private TMP_Text[,] textLines = new TMP_Text[3,5];

    void Start()
    {
        //Combine editorLines into 2d array since Unity Editor doesn't support
        for (int y = editorLines1.Length - 1; y >= 0; y--)
        {
            textLines[0, y] = editorLines1[y];
            textLines[1, y] = editorLines2[y];
            textLines[2, y] = editorLines3[y];
        }

        //Clear text add array to prevent issues
        for (int x = textToAdd.Length - 1; x >= 0; x--)
        {
            textToAdd[x] = "";
        }

        ClearGrid();
    }

    void Update()
    {
        if (textToAdd[0] != "" || textToAdd[1] != "" || textToAdd[2] != "") //Keep adding letters if in queue
        {
            typeCounter += Time.deltaTime;
            if (typeCounter > typeLimit)
            {
                for (int x = textLines.GetLength(0)-1; x >= 0; x--)
                {
                    if (textToAdd[x] != "")
                    {
                        textLines[x, 0].text += textToAdd[x].Substring(0, 1);
                    }

                    if (textToAdd[x].Length > 0)
                    {
                        textToAdd[x] = textToAdd[x].Substring(1);
                    }
                    else
                    {
                        textToAdd[x] = "";
                    }
                }
                typeCounter = 0;
            }
        }
    }

    public void AddText(string[] newText)
    {
        if (start)  //Remove animated character once text will be added
        {
            Destroy(Blink);
            start = false;
        }

        //Check for unfinished text lines & quickly complete
        for (int x = textToAdd.Length - 1; x >= 0; x--)
        {
            if (textToAdd[x] != "")
            {
                textLines[x,0].text += textToAdd[x];
            }
        }

        //Shift up lines in Array to clear room for new
        for (int x = textLines.GetLength(0) - 1; x >= 0; x--)
        {
            for (int y = textLines.GetLength(1) - 1; y >= 1; y--)
            {
                textLines[x, y].text = textLines[x, y - 1].text;
            }
        }

        //Clear bottom line to make room for new text to push
        textLines[0, 0].text = "";
        textLines[1, 0].text = "";
        textLines[2, 0].text = "";

        //Add new line
        textToAdd = newText;
    }

    private void ClearGrid()
    {
        //Clear screen text array
        for (int x = textLines.GetLength(0) - 1; x >= 0; x--)
        {
            for (int y = textLines.GetLength(1) - 1; y >= 0; y--)
            {
                textLines[x, y].text = "";
            }
        }
    }
}
