using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RUDE;

/// <summary>
/// Enum for drop down list in editor
/// </summary>
public enum VerbEnum
{
    OnMouseDown, OnMouseDrag, OnMouseEnter, OnMouseExit, OnMouseOver, OnCollisionEnter, OnCollisionExit, OnCollisionStay, OnDestroy, OnCreate, OnTriggerEnter, OnTriggerExit,
    OnTriggerStay, OnEnable, OnDisable, OnScroll
}

[HelpURL("https://github.com/vmasc-capabilities-lab/RUDE/wiki/How-to-Use#eventlogger")]
public class DemoEventLogger : MonoBehaviour
{

    [SerializeField]
    [Tooltip("The action that has occurred")]
    public string Verb;

    [SerializeField]
    [Tooltip("What has been modified by the Verb")]
    public string Object;

    [SerializeField]
    [Tooltip("Additional information tied to this event. This can be anything from a detail separating it from others logged, or a small description")]
    public string Payload;

    private DemoEventsManager eventManagerInstance = null;

    [SerializeField]
    [Tooltip("Indicates which Unity Event you wish to log when it occurs.")]
    public VerbEnum Options;

    /// flag for object created fir onCreate
    private bool created = false;
    /// flag for manager object created for onEnable
    private bool onManager = false;

    /// flag for application state
    private bool isPaused = false;

    private void Start()
    {

        // Finds RudeManager instance for logger object
        GameObject tempObj = GameObject.Find("DemoRudeManager");
        eventManagerInstance = tempObj.GetComponent<DemoEventsManager>();


        onManager = true;

    }

    private void Update()
    {
        if (Options == VerbEnum.OnCreate)
        {
            if (this.gameObject.scene.IsValid() && !created)
            {
                eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
                created = true;
            }
        }

    }

    private void OnMouseDown()
    {
        if (Options == VerbEnum.OnMouseDown)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
            Debug.Log("Logged Event, Object: " + Object + " ,Verb: " + Verb);
            SendText();
        }

    }

    private void OnMouseDrag()
    {
        if (Options == VerbEnum.OnMouseDrag)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
            Debug.Log("Logged Event, Object: " + Object + " ,Verb: " + Verb);
            SendText();
        }
    }

    private void OnMouseEnter()
    {
        if (Options == VerbEnum.OnCollisionEnter)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
            Debug.Log("Logged Event, Object: " + Object + " ,Verb: " + Verb);
            SendText();
        }
    }

    private void OnMouseExit()
    {
        if (Options == VerbEnum.OnMouseExit)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
            Debug.Log("Logged Event, Object: " + Object + " ,Verb: " + Verb);
            SendText();
        }
    }

    private void OnMouseOver()
    {
        if (Options == VerbEnum.OnMouseOver)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
            Debug.Log("Logged Event, Object: " + Object + " ,Verb: " + Verb);
            SendText();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (Options == VerbEnum.OnCollisionEnter)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
            Debug.Log("Logged Event, Object: " + Object + " ,Verb: " + Verb);
            SendText();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (Options == VerbEnum.OnCollisionExit)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
            Debug.Log("Logged Event, Object: " + Object + " ,Verb: " + Verb);
            SendText();
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (Options == VerbEnum.OnCollisionStay)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
            Debug.Log("Logged Event, Object: " + Object + " ,Verb: " + Verb);
            SendText();
        }
    }


    private void OnDestroy()
    {
        /// isPaused identifies current state of game, destroyed log event will occur when exiting game if not implemented
        if (Options == VerbEnum.OnDestroy && !isPaused)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
            Debug.Log("Logged Event, Object: " + Object + " ,Verb: " + Verb);
            SendText();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Options == VerbEnum.OnTriggerEnter)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
            Debug.Log("Logged Event, Object: " + Object + " ,Verb: " + Verb);
            SendText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Options == VerbEnum.OnCollisionExit)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
            Debug.Log("Logged Event, Object: " + Object + " ,Verb: " + Verb);
            SendText();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Options == VerbEnum.OnCollisionStay)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
            Debug.Log("Logged Event, Object: " + Object + " ,Verb: " + Verb);
            SendText();
        }
    }

    private void OnEnable()
    {
        if (Options == VerbEnum.OnEnable && onManager)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
            Debug.Log("Logged Event, Object: " + Object + " ,Verb: " + Verb);
            SendText();
        }
    }

    private void OnDisable()
    {
        if (Options == VerbEnum.OnDisable)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
            Debug.Log("Logged Event, Object: " + Object + " ,Verb: " + Verb);
            SendText();
        }
    }

    private void OnScroll()
    {
        if (Options == VerbEnum.OnScroll)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
            Debug.Log("Logged Event, Object: " + Object + " ,Verb: " + Verb);
            SendText();
        }
    }

    private void SendText()
    {
        GameObject[] reader = GameObject.FindGameObjectsWithTag("TextReader");
        string[] textArray = new string[3];
        textArray[0] = System.DateTime.Now.ToString();
        textArray[1] = Object;
        textArray[2] = Verb;
        reader[0].SendMessage("WriteToScreen", textArray);
    }


    private void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !hasFocus;
    }


}
