using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirConsoleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AirConsole.instance.onMessage += OnMessage;
    }

    void OnMessage(int deviceId, JToken data)
    {
        Debug.Log("from " + deviceId + ": " + data);

        string action = (string)data["action"];
        Debug.Log("from " + deviceId + ": " + action);

        var message = new {
            action = "move",
            info = new { amount = 5, torque = 234.8f }
        };

        AirConsole.instance.Message(deviceId, message);
    }

    private void OnDestroy()
    {
        if (AirConsole.instance != null)
        {
            AirConsole.instance.onMessage -= OnMessage;
        }
    }
}
