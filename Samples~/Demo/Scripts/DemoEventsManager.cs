using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using RUDE;
using System;


public class DemoEventsManager : MonoBehaviour
{
[SerializeField]
    public Log logger;

    [SerializeField]
    public string Study;

    [Header("Azure")]

    [SerializeField]
    public string ConnectionString;

    [SerializeField]
    public File UploadFileType;

    public void Awake()     //Allow Player to move from scene to scene
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Start() {

        logger = new Log(Study, Application.persistentDataPath.ToString());
        Debug.Log(Application.persistentDataPath);

    }

    private void OnApplicationQuit() {

        logger.LogEvent("Ended", "Scene");

        if (!String.IsNullOrEmpty(ConnectionString))
        {
            logger.uploadAzure(UploadFileType.ToString(), ConnectionString);            
        }

        
    }

}
