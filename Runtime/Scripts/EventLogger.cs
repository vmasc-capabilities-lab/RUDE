using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RUDE;

public enum Verb
{
    OnMouseDown, OnMouseDrag, OnMouseEnter, OnMouseExit, OnMouseOver, OnCollisionEnter, OnCollisionExit, OnCollisionStay, OnDestroy, OnTriggerEnter, OnTriggerExit,
    OnTriggerStay, OnEnable, OnDisable, OnScroll
}


public class EventLogger : MonoBehaviour
{
    // [SerializeField]
    // public LogEvent aLogEvent;
    public string Subject;

    public string Payload;

    private EventsManager eventManagerInstance = null;

    [SerializeField]
    public Verb Options;

    private void Start() 
    {

        GameObject tempObj = GameObject.Find("RudeManager");
        eventManagerInstance = tempObj.GetComponent<EventsManager>();

    }

    private void OnMouseDown() 
    {
        if(Options == Verb.OnMouseDown)
        {
            eventManagerInstance.logger.LogEvent(Subject, Payload);
            Debug.Log("LOGGED");
        }

    }

    private void OnMouseDrag() 
    {
        if(Options == Verb.OnMouseDrag)
        {
            eventManagerInstance.logger.LogEvent(Subject, Payload);
            Debug.Log("LOGGED");
        }        
    }

    private void OnMouseEnter() 
    {
        if(Options == Verb.OnCollisionEnter)
        {
            eventManagerInstance.logger.LogEvent(Subject, Payload);
            Debug.Log("LOGGED");
        }        
    }

    private void OnMouseExit() 
    {
        if(Options == Verb.OnMouseExit)
        {
            eventManagerInstance.logger.LogEvent(Subject, Payload);
            Debug.Log("LOGGED");
        }        
    }

    private void OnMouseOver() 
    {
        if(Options == Verb.OnMouseOver)
        {
            eventManagerInstance.logger.LogEvent(Subject, Payload);
            Debug.Log("LOGGED");
        }        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(Options == Verb.OnCollisionEnter)
        {
            eventManagerInstance.logger.LogEvent(Subject, Payload);
            Debug.Log("LOGGED");
        }
    }

    private void OnCollisionExit(Collision other) 
    {
        if(Options == Verb.OnCollisionExit)
        {
            eventManagerInstance.logger.LogEvent(Subject, Payload);
            Debug.Log("LOGGED");
        }        
    }

    private void OnCollisionStay(Collision other) 
    {
        if(Options == Verb.OnCollisionStay)
        {
            eventManagerInstance.logger.LogEvent(Subject, Payload);
            Debug.Log("LOGGED");
        }        
    }


    private void OnDestroy() 
    {
        if(Options == Verb.OnDestroy)
        {
            eventManagerInstance.logger.LogEvent(Subject, Payload);
            Debug.Log("LOGGED");
        }             
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(Options == Verb.OnTriggerEnter)
        {
            eventManagerInstance.logger.LogEvent(Subject, Payload);
            Debug.Log("LOGGED");
        }      
    }

    private void OnTriggerExit(Collider other) 
    {
        if(Options == Verb.OnCollisionExit)
        {
            eventManagerInstance.logger.LogEvent(Subject, Payload);
            Debug.Log("LOGGED");
        }        
    }

    private void OnTriggerStay(Collider other) 
    {
        if(Options == Verb.OnCollisionStay)
        {
            eventManagerInstance.logger.LogEvent(Subject, Payload);
            Debug.Log("LOGGED");
        }        
    }

    private void OnEnable() 
    {
        if(Options == Verb.OnDisable)
        {
            eventManagerInstance.logger.LogEvent(Subject, Payload);
            Debug.Log("LOGGED");
        }        
    }

    private void OnDisable() 
    {
        if(Options == Verb.OnDisable)
        {
            eventManagerInstance.logger.LogEvent(Subject, Payload);
            Debug.Log("LOGGED");
        }        
    }

    private void OnScroll()
    {
        if(Options == Verb.OnScroll)
        {
            eventManagerInstance.logger.LogEvent(Subject, Payload);
            Debug.Log("LOGGED");
        }
    }


}
