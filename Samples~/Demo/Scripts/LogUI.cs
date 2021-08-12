
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using UnityEngine.Events;
using RUDE;

namespace VMASC.Logger
{

        public class MyDate
    {
        public int year;
        public int month;
        public int day;
    }

    public class Lad
    {
        public string firstName;
        public string lastName;
        public MyDate dateOfBirth;
    }
    public class LogUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject item = null;

        [SerializeField]
        private RectTransform content = null;

        [SerializeField]
        public string fileName = "IntentData1";

        LogBase logBase;

        public static string connectionString = "DefaultEndpointsProtocol=https;AccountName=rudeblobtesting;AccountKey=Vo1nh1aiEvfFZKJUMmK2fUX6geOaJzJz/OJ+JxNL8qa8GRk44u7DmazfgDW8DiHbFWhqOMKP5xVCBiU4G9N5pA==;EndpointSuffix=core.windows.net";
        private LogEvents logEvent;
        public KeyCode LogEventTriggerKey = KeyCode.Space;
        string datetimeFormat = "MM/dd/yyyy HH:mm:ss";
        private string dataPath;


        // Start is called before the first frame update
        async void Start()
        {

                        var obj = new Lad
            {
                firstName = "Markoff",
                lastName = "Chaney",
                dateOfBirth = new MyDate
                {
                    year = 1901,
                    month = 4,
                    day = 30
                }
            };

            Log logger = new Log(connectionString, false);
                        logger.LogData("Log.LogType.AR", obj);
            logger.LogData("L.AsdasdR", "sdasdadsad");
            logger.LogData("Log.LogType.AR", "osdsdbj");
            logger.LogData("Log.asdasdasdasd.AR", obj);
            logger.LogData("Log.LogType.AR", obj);
            logger.uploadAzure();
            Debug.Log(Application.persistentDataPath);
            dataPath = Application.persistentDataPath;
            logBase = new LogBase(fileName);
            logEvent = new LogEvents();
            logEvent.AddListener(LogItem);
            PopulateListFromText(fileName);


        }

        /// <summary>
        /// Called when LogEvent is invoked, takes params and populates scrollview.
        /// Calls LogBase.LogData which outputs two files, one normal text and one json format
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="type"></param>
        /// <param name="text"></param>
        public void LogItem(string FileName, LogBase.LogType type, string text)
        {

            //instantiate item
            GameObject SpawnedItem = Instantiate(item);
            //setParent
            SpawnedItem.transform.SetParent(content, false);
            //get ItemDetails Component
            LogItem itemLog = SpawnedItem.GetComponent<LogItem>();

            itemLog.text_time.text = DateTime.Now.ToString(datetimeFormat);
            itemLog.text_description.text = text;
            itemLog.text_dataType.text = type.ToString();

            logBase.LogData(type, text);

        }

        /// <summary>
        /// Takes name of file that user wishes to save to, creates a path
        /// Checks if json path exists, if it does it populates the scrollview with items
        /// </summary>
        /// <param name="filename"></param>
        public void PopulateListFromText(string filename)
        {
            string jsonPath = dataPath + "/" + fileName + "json.txt";
            if (File.Exists(jsonPath))
            {
                // List<Log.LogObject> list = logBase.LoadJson(jsonPath);
                // foreach (Log. logItem in list)
                // {
                //     //instantiate item
                //     GameObject SpawnedItem = Instantiate(item);
                //     //setParent
                //     SpawnedItem.transform.SetParent(content, false);

                //     //get ItemDetails Component
                //     LogItem itemLog = SpawnedItem.GetComponent<LogItem>();

                //     itemLog.text_time.text = logItem.dateTime;
                //     itemLog.text_description.text = logItem.data;
                //     itemLog.text_dataType.text = logItem.logType;
                // }
            }
        }

        void OnDisable()
        {
            logEvent.RemoveAllListeners();
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(LogEventTriggerKey))
            {
                logEvent.Invoke(fileName, LogBase.LogType.Intent, "Closure");
                logEvent.Invoke(fileName, LogBase.LogType.AR, "Hello AR");
            }

        }


    }

}

