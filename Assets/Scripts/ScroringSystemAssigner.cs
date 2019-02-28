using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScroringSystemAssigner : MonoBehaviour
{
    [SerializeField] private ScoreScript scoringSystem;
    // Start is called before the first frame update
    void Start()
    {
        scoringSystem.AddPlayerToTheList(this.gameObject);
    }
}
