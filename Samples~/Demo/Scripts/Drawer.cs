using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    private Animator drawerAnim;
    private bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        drawerAnim = GetComponent<Animator>();
    }

    public void Clicked()
    {
        if (open)
        {
            drawerAnim.SetTrigger("Close");
            open = false;
        } else
        {
            drawerAnim.SetTrigger("Open");
            open = true;
        }
    }
}
