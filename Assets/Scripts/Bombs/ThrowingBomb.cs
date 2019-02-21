using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBomb : Bomb
{
    private int bounces = 0;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            bounces++;
            if (bounces >= 3)
            {
                Explode();
            }
        } else if (collision.gameObject != Owner)
        {
            Explode();
        }
    }
}
