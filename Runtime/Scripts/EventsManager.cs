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

[HelpURL("https://github.com/vmasc-capabilities-lab/RUDE/wiki")]
public class EventsManager : MonoBehaviour
{
    [SerializeField]
    public Log logger;

    [SerializeField]
    [Tooltip("Tooltip goes here!")]
    public string SessionNameForLog;

    [Header("Local")]

    [SerializeField]
    [Tooltip("Tooltip goes here!")]
    public string FilePathToWriteLogsTo;


    [Header("Azure")]

    [SerializeField]
    [Tooltip("Tooltip goes here!")]
    public string ConnectionString;

    [SerializeField]
    [Tooltip("Tooltip goes here!")]
    public File UploadFileType;

    [Header("AWS")]

    [SerializeField]
    [Tooltip("Tooltip goes here!")]
    public string AccessKey;

    [SerializeField]
    [Tooltip("Tooltip goes here!")]
    public string SecretKey;


    public void Awake()
    {
        //Allows RudeManager to move from scene to scene
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        ///Init logger
        logger = new Log(SessionNameForLog, Application.persistentDataPath.ToString());

        Debug.Log("Temp log files located at :" + Application.persistentDataPath);

    }


    private void OnApplicationQuit()
    {

        ///When application quits, upload log to users choice
        if (!String.IsNullOrEmpty(FilePathToWriteLogsTo))
        {
            logger.uploadLocal(UploadFileType.ToString(), FilePathToWriteLogsTo);
        }
        else if (!String.IsNullOrEmpty(ConnectionString))
        {
            logger.uploadAzure(UploadFileType.ToString(), ConnectionString);
        }
        else if (!String.IsNullOrEmpty(AccessKey) && !String.IsNullOrEmpty(SecretKey))
        {
            ///uploadAWS
        }


    }

}
