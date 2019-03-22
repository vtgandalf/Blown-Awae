using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoScript : MonoBehaviour
{
    public KeyCode resetKey;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(resetKey))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
