using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace VMASC.Logger
{
    public class LogBase : MonoBehaviour
    {

        private readonly string textPath;
        private readonly string jsonPath;
        private readonly string dataPath = Application.persistentDataPath;
        string datetimeFormat;
        bool append = true;
        parentLogObject parentLog;

        /// <summary>
        /// Creates LogBase instance
        /// </summary>
        /// <param name="fileName"></param>
        public LogBase(string fileName)
        {
            datetimeFormat = "MM/dd/yyyy HH:mm:ss";
            textPath = dataPath + "/" + fileName + ".txt";
            jsonPath = dataPath + "/" + fileName + "json.txt";
            //Brandon Unity doesn't work like this - I wish it did! but it doesnt
            //Unity has to have the object be part of/attached to something you can do this from another c# class and have Unity reference that class - similar to the utility
            //you can also just make this a mono base class
            parentLog = new parentLogObject();
            parentLog.logBaseCollection = new List<LogObject>();

        }

        /// <summary>
        /// JSON utitlity only saves one root so this class is needed to print out multiple LogObjects
        /// </summary>
        [Serializable]
        public class parentLogObject
        {
            public List<LogObject> logBaseCollection;
        }

        /// <summary>
        /// LogObject class consisting of 3 strings
        /// </summary>
        [Serializable]
        public class LogObject
        {
            public string logType;
            public string data;
            public string dateTime;
        }

        /// <summary>
        /// Calls FormatLog and SaveJson 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="text"></param>
        public void LogData(LogType type, string text)
        {
            FormatLog(type, text);
            SaveJson(type, text);
        }

        /// <summary>
        /// Formats the given parems, switch case not really needed but kept just in case we need different formats for each log type
        /// Outputs to a text file
        /// </summary>
        /// <param name="type"></param>
        /// <param name="text"></param>
        private void FormatLog(LogType type, string text)
        {
            string fulltext = "";
            switch (type)
            {
                case LogType.AR:
                    fulltext = DateTime.Now.ToString(datetimeFormat) + " " +
                        LogType.AR.ToString() + " " + text;
                    break;
                case LogType.Intent:
                    fulltext = DateTime.Now.ToString(datetimeFormat) + " " +
                        LogType.Intent.ToString() + " " + text;
                    break;
                case LogType.Light:
                    fulltext = DateTime.Now.ToString(datetimeFormat) + " " +
                         LogType.Light.ToString() + " " + text;
                    break;
                case LogType.State:
                    fulltext = DateTime.Now.ToString(datetimeFormat) + " " +
                        LogType.State.ToString() + " " + text;
                    break;
                default:
                    fulltext = DateTime.Now.ToString(datetimeFormat) + " " +
                        type + " " + text;
                    break;
            }



            Debug.Log(type + " Logged");
            WriteLine(textPath, fulltext);
        }

        /// <summary>
        /// Ouputs given text to text file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        private void WriteLine(string path, string text)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path, append))
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        streamWriter.WriteLine(text);

                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Creates new instance of LogObject, adds it to parentLog list of logobjects, converts to json, and outputs to text file
        /// </summary>
        /// <param name="type"></param>
        /// <param name="text"></param>
        private void SaveJson(LogType type, string text)
        {
            LogObject tempLogObject = new LogObject
            {
                logType = type.ToString(),
                data = text,
                dateTime = DateTime.Now.ToString(datetimeFormat)

            };
            parentLog.logBaseCollection.Add(tempLogObject);
            string ChildJSONString = JsonUtility.ToJson(parentLog, true);
            File.WriteAllText(jsonPath, ChildJSONString);
        }

        /// <summary>
        /// Loads json file passed into parentLog class and returns the list of logobjects inside of parentlog
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<LogObject> LoadJson(string path)
        {
            parentLog = JsonUtility.FromJson<parentLogObject>(File.ReadAllText(path));
            return parentLog.logBaseCollection;
        }

        /// <summary>
        /// Types of items you wish to log
        /// </summary>
        public enum LogType
        {
            Intent, AR, State, Light, PreCheck, CallJoined, MicOff, MicOn, CallEnded
        }
    }

}