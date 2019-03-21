using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombEffect : ScriptableObject
{
    public Sprite image;
    public virtual void Activate(List<BombInteractable> hits) { }
}
