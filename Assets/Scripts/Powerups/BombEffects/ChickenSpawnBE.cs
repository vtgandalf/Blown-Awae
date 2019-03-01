using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chicken Spawner", menuName = "Powerup/BombEffect/ChickenSpawner")]
public class ChickenSpawnBE : BombEffect
{
    public ChickenSpawner chickenSpawnerPrefab;
    public ChickenSettings chickenSettings;

    public override void Activate(List<BombInteractable> hits)
    {
        base.Activate(hits);
        foreach (BombInteractable bi in hits)
        {
            if (bi.type == InteractableType.PLAYER)
            {
                ChickenSpawner cs = Instantiate(chickenSpawnerPrefab, bi.transform);
                cs.SetChickenSettings(chickenSettings);
            }
        }
    }
}
