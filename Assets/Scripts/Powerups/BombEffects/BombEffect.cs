﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BombEffect : ScriptableObject
{
    public Player Owner;
    public Sprite Image;
    public virtual void Activate(List<BombInteractable> hits) { }
}
