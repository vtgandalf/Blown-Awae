using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeIndicator : MonoBehaviour
{
    [SerializeField]private Image Image;
    [SerializeField]private PlayerController PlayerController;

    // Update is called once per frame
    void Update()
    {
        Image.fillAmount = PlayerController.ThrowCharge();
    }
}
