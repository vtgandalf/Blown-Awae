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
        Debug.Log("from " + deviceId + ": data");
        if (data["action"] != null && data["action"].ToString().Equals("interact"))
        {
            Camera.main.backgroundColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }

    void OnDestroy()
    {
        if (AirConsole.instance != null)
        {
            AirConsole.instance.onMessage -= OnMessage;
        }
    }
}
