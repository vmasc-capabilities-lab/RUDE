using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RUDE;

public class DemoEventLogger : MonoBehaviour
{

    public string Verb;

    public string Object;

    public string Payload;

    private EventsManager eventManagerInstance = null;

    [SerializeField]
    public VerbEnum Options;

    /// flag for object created fir onCreate
    private bool created = false;
    /// flag for manager object created for onEnable
    private bool onManager = false;

    private void Start()
    {

        // Finds RudeManager instance for logger object
        GameObject tempObj = GameObject.Find("RudeManager");
        eventManagerInstance = tempObj.GetComponent<EventsManager>();


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
        if (Options == VerbEnum.OnDestroy)
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



}
