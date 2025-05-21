using System;
using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using UnityEngine;
using Random = UnityEngine.Random;


public class OrbSpawner : MonoBehaviour
{
  public GameObject orbPrefab;
  public int orbCount = 10;
  public float height;
  
  public List<GameObject> orbsSpawned;
  
  public float minEdgeDistance = 0.2f;
  public MRUKAnchor.SceneLabels spawnLabels;
  public float normalOffset = 0.1f; // Pequeño offset para evitar clipping

  private void Start()
  {
    MRUK.Instance.RegisterSceneLoadedCallback(SpawnOrbs);
  }


  public void SpawnOrbs()
  {
    for (int i = 0; i < orbCount; i++)
    {
      Vector3 randomPosition = Vector3.zero;

      MRUKRoom room = MRUK.Instance.GetCurrentRoom();
      
      bool hasFound = room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.FACING_UP, 1, LabelFilter.Included(
        MRUKAnchor.SceneLabels.FLOOR), out randomPosition, out Vector3 n);

      randomPosition.y = height;
      
      GameObject orb = Instantiate(orbPrefab, randomPosition, Quaternion.identity);
      
      orbsSpawned.Add(orb);
    }
  }

}
