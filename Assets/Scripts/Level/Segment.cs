﻿using UnityEngine;

public class Segment : MonoBehaviour, IPoolable
{
    PoolableRbSpot[] _poolableRbSpots;
    void Awake() => _poolableRbSpots = GetComponentsInChildren<PoolableRbSpot>();
    public void OnSpawn()
    {
        foreach (PoolableRbSpot spot in _poolableRbSpots)
        {
            Transform spotTransform = spot.transform;
            GameObject instance = PoolManager.Spawn(spot.prefabToSpawn, spotTransform.position, spotTransform.rotation, null);
            if (spot.usePrefabScale)
            {
                instance.transform.localScale = spot.prefabToSpawn.transform.localScale;
            }
            if (instance.TryGetComponent(out PoolableRBObject poolableRBObject))
            {
                poolableRBObject.prefab = spot.prefabToSpawn;
            }
        }
    }
    public void OnDespawn() {}
}
