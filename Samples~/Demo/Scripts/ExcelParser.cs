using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ExcelParser : MonoBehaviour
{
    public ScreenGrid screenGrid;


    public void WriteToScreen(string[] textToPass)
    {
        screenGrid.AddText(textToPass);
    }


}
