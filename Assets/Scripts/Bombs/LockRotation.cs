using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
	private Quaternion initRotation;

    // Start is called before the first frame update
    void Start()
    {
		initRotation = Quaternion.Euler (90, 0, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
		transform.rotation = initRotation;
    }
}
