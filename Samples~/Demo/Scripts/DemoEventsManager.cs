using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using RUDE;
using System;

[HelpURL("https://github.com/vmasc-capabilities-lab/RUDE/wiki/How-to-Use#eventsmanager")]
public class DemoEventsManager : MonoBehaviour
{
    [SerializeField]
    public Log logger;

    [SerializeField]
    [Tooltip("Unique string identifier for the log session.")]
    public string SessionNameForLog;

    [Header("Local")]

    [SerializeField]
    [Tooltip("The Path location you wish to store log files to. This must be an Absolute path.")]
    public string FilePathToWriteLogsTo;


    [Header("Azure")]

    [SerializeField]
    [Tooltip("Connection string used to access Azure Storage account.")]
    public string ConnectionString;

    [SerializeField]
    [Tooltip("The type of file you wish to store the logs to.")]
    public File UploadFileType;

    [Header("AWS")]

    [SerializeField]
    [Tooltip("An access key grants programmatic access to AWS resources")]
    public string AccessKey;

    [SerializeField]
    [Tooltip("An access key...but secret...that grants programmatic access to AWS resources")]
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
        ///Log for Demo
        logger.LogEvent("Ended", "Scene");

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
