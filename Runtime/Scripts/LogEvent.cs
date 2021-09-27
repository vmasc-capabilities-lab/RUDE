using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[SerializeField]
public class LogEvent : UnityEvent<string, string, string>
{

}
