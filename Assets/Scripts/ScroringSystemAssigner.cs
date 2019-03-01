using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScroringSystemAssigner : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<ScoreScript>().AddPlayerToTheList(gameObject);
    }
}
