using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public string[] passingText;

    private ScreenGrid screenGrid;
    private Animator animator;
    private int buttonCount = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        screenGrid = GameObject.Find("Monitor").GetComponent<ScreenGrid>();
    }

    public void ButtonPress()
    {
        animator.SetTrigger("Press");
        if (passingText.Length > 0)
        {
            /*if (buttonCount < passingText.Length)
            {
                string[] newPass = new string[3];
                newPass[0] = System.DateTime.Now.ToString();
                newPass[1] = "Button";
                newPass[2] = passingText[buttonCount];

                screenGrid.AddText(newPass);
                buttonCount++;
            }*/
        } else
        {
            GameObject.Find("ScreenMachine").GetComponent<Animator>().SetTrigger("Switch");
        }
    }
}
