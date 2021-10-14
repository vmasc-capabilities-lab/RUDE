using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RUDE;

/// <summary>
/// Enum for drop down list in editor
/// </summary>
public enum Verb
{
    OnMouseDown, OnMouseDrag, OnMouseEnter, OnMouseExit, OnMouseOver, OnCollisionEnter, OnCollisionExit, OnCollisionStay, OnDestroy, OnCreate,  OnTriggerEnter, OnTriggerExit,
    OnTriggerStay, OnEnable, OnDisable, OnScroll
}


public class EventLogger : MonoBehaviour
{

    public string Subject;

    public string Object;

    public string Payload;

    private EventsManager eventManagerInstance = null;

    [SerializeField]
    public Verb Options;

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
        if(Options == Verb.OnCreate)
        {
            if(this.gameObject.scene.IsValid() && !created)
            {
                eventManagerInstance.logger.LogEvent(Subject, Object, Payload);
                created = true;
            }
        } 

    }

    private void OnMouseDown() 
    {
        if(Options == Verb.OnMouseDown)
        {
            eventManagerInstance.logger.LogEvent(Subject, Object, Payload);
        }

    }

    private void OnMouseDrag() 
    {
        if(Options == Verb.OnMouseDrag)
        {
            eventManagerInstance.logger.LogEvent(Subject, Object, Payload);
        }        
    }

    private void OnMouseEnter() 
    {
        if(Options == Verb.OnCollisionEnter)
        {
            eventManagerInstance.logger.LogEvent(Subject, Object, Payload);
        }        
    }

    private void OnMouseExit() 
    {
        if(Options == Verb.OnMouseExit)
        {
            eventManagerInstance.logger.LogEvent(Subject, Object, Payload);
        }        
    }

    private void OnMouseOver() 
    {
        if(Options == Verb.OnMouseOver)
        {
            eventManagerInstance.logger.LogEvent(Subject, Object, Payload);
        }        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(Options == Verb.OnCollisionEnter)
        {
            eventManagerInstance.logger.LogEvent(Subject, Object, Payload);
        }
    }

    private void OnCollisionExit(Collision other) 
    {
        if(Options == Verb.OnCollisionExit)
        {
            eventManagerInstance.logger.LogEvent(Subject, Object, Payload);
        }        
    }

    private void OnCollisionStay(Collision other) 
    {
        if(Options == Verb.OnCollisionStay)
        {
            eventManagerInstance.logger.LogEvent(Subject, Object, Payload);
        }        
    }


    private void OnDestroy() 
    {
        if(Options == Verb.OnDestroy)
        {
            eventManagerInstance.logger.LogEvent(Subject, Object, Payload);
        }             
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(Options == Verb.OnTriggerEnter)
        {
            eventManagerInstance.logger.LogEvent(Subject, Object, Payload);
        }      
    }

    private void OnTriggerExit(Collider other) 
    {
        if(Options == Verb.OnCollisionExit)
        {
            eventManagerInstance.logger.LogEvent(Subject, Object, Payload);
        }        
    }

    private void OnTriggerStay(Collider other) 
    {
        if(Options == Verb.OnCollisionStay)
        {
            eventManagerInstance.logger.LogEvent(Subject, Object, Payload);
        }        
    }

    private void OnEnable() 
    {
        if(Options == Verb.OnEnable && onManager)
        {
            eventManagerInstance.logger.LogEvent(Subject, Object, Payload);
        }        
    }

    private void OnDisable() 
    {
        if(Options == Verb.OnDisable)
        {
            eventManagerInstance.logger.LogEvent(Subject, Object, Payload);
        }        
    }

    private void OnScroll()
    {
        if(Options == Verb.OnScroll)
        {
            eventManagerInstance.logger.LogEvent(Subject, Object, Payload);
        }
    }


}
