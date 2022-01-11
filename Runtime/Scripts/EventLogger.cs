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

public class EventLogger : MonoBehaviour
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
        }

    }

    private void OnMouseDrag()
    {
        if (Options == VerbEnum.OnMouseDrag)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
        }
    }

    private void OnMouseEnter()
    {
        if (Options == VerbEnum.OnCollisionEnter)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
        }
    }

    private void OnMouseExit()
    {
        if (Options == VerbEnum.OnMouseExit)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
        }
    }

    private void OnMouseOver()
    {
        if (Options == VerbEnum.OnMouseOver)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (Options == VerbEnum.OnCollisionEnter)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (Options == VerbEnum.OnCollisionExit)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (Options == VerbEnum.OnCollisionStay)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
        }
    }


    private void OnDestroy()
    {
        if (Options == VerbEnum.OnDestroy)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Options == VerbEnum.OnTriggerEnter)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Options == VerbEnum.OnCollisionExit)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Options == VerbEnum.OnCollisionStay)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
        }
    }

    private void OnEnable()
    {
        if (Options == VerbEnum.OnEnable && onManager)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
        }
    }

    private void OnDisable()
    {
        if (Options == VerbEnum.OnDisable)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
        }
    }

    private void OnScroll()
    {
        if (Options == VerbEnum.OnScroll)
        {
            eventManagerInstance.logger.LogEvent(Verb, Object, Payload);
        }
    }



}
