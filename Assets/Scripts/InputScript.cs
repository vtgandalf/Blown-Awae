using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputScript", menuName = "Blown-Awae/InputScript", order = 0)]
public abstract class InputScript : ScriptableObject {
    public KeyCode bigBomb, throwingBomb;
    public abstract float GetHorizontal();

    public abstract float GetVertical();
}
