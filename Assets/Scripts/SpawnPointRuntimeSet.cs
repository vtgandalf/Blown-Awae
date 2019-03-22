using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpawnPointRuntimeSet : RuntimeSet<Vector3>
{
    private List<Vector3> unusedSpawnPoints;

    private void OnEnable()
    {
        ResetSpawnPoints();
        OnAddItem.AddListener(AddSpawnPoint);
        OnRemoveItem.AddListener(RemoveSpawnPoint);
    }

    private void OnDisable()
    {
        OnAddItem.RemoveAllListeners();
        OnRemoveItem.RemoveAllListeners();
    }

    private void AddSpawnPoint(Vector3 spawnPoint)
    {
        if (!unusedSpawnPoints.Contains(spawnPoint))
        {
            unusedSpawnPoints.Add(spawnPoint);
        }
    }

    private void RemoveSpawnPoint(Vector3 spawnPoint)
    {
        if (unusedSpawnPoints.Contains(spawnPoint))
        {
            unusedSpawnPoints.Remove(spawnPoint);
        }
    }

    public void ResetSpawnPoints()
    {
        unusedSpawnPoints = new List<Vector3>(Items);
    }

    public Vector3 GetRandomUnusedSpawnPoint()
    {
        if (unusedSpawnPoints.Count == 0)
            ResetSpawnPoints();

        Vector3 spawnPoint = unusedSpawnPoints[Random.Range(0, unusedSpawnPoints.Count - 1)];
        unusedSpawnPoints.Remove(spawnPoint);
        return spawnPoint;
    }
}
