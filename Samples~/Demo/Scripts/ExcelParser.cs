using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ExcelParser : MonoBehaviour
{
    public string filepath;
    public ScreenGrid screenGrid;

    private float readTimer = 0;
    private float readLim = 1;  //Prevents CSV read every frame

    private bool inUse = false;

    private int lastRead = 0;   //Determines last text passed to screen

    /*
     * For demo, make sure 2 different events don't happen within the same second!
     * Can't increase read time due to write time.
     * Can add a try/catch to see when writing occurs
     */

    public void DataLogged()
    {
        List<string> data = new List<string>();

        StreamReader strReader = new StreamReader(filepath);
        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = strReader.ReadLine();
            if (data_String == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_String.Split(',');
            data.AddRange(data_values);
        }
        string[] dataArray = data.ToArray();
        PassToScreen(dataArray);
    }

    public void WriteToScreen(string[] textToPass)
    {
        screenGrid.AddText(textToPass);
    }

    void PassToScreen(string[] data)
    {
        if (data.Length > lastRead)
        {
            if (lastRead >= 3)
            {
                string[] textToPass = new string[3];

                textToPass[0] = data[lastRead + 1]; //Time
                textToPass[1] = data[lastRead + 2]; //Time
                textToPass[2] = data[lastRead + 4]; //Time

                Debug.Log(textToPass[0] + " " + textToPass[1] + " " + textToPass[2]);

                screenGrid.AddText(textToPass);
            }
            lastRead += 4;
        }
    }
}
