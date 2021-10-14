using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using RUDE;
using System;

public enum File
{
    CSV, JSON, TXT
}


public class EventsManager : MonoBehaviour 
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

        if(!String.IsNullOrEmpty(ConnectionString))
        {
            logger.uploadAzure(UploadFileType.ToString(), ConnectionString);            
        }

        
    }
    // SerializedProperty onLog;

    // private void OnEnable() {
    //     onLog = serializedObject.FindProperty("aLogEvent");
    // }

    // public override void OnInspectorGUI() 
    // {
    //    // base.OnInspectorGUI();

    //     serializedObject.Update();

    //     EditorGUILayout.PropertyField(onLog);

    //     serializedObject.ApplyModifiedProperties();
        
    // }
}