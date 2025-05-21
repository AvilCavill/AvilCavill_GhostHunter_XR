using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Meta.XR.MRUtilityKit;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public float spawnInterval = 1.0f;
    public GameObject ghostPrefab;
    public int ghostCount = 20;

    public float minEgeDistance = 0.2f;
    public MRUKAnchor.SceneLabels spawnLabels;
    public float normalOffset = -1.5f;
    void Start()
    {
        StartCoroutine(SpawnGhostCoroutine());
    }

    private IEnumerator SpawnGhostCoroutine()
    {
        while (ghostCount > 0)
        {
            ghostCount--;
            yield return new WaitForSeconds(spawnInterval);
            SpawnGhost();
        }
    }

    public void SpawnGhost()
    {
        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        bool hasFoundPosition = room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.VERTICAL, minEgeDistance, 
            LabelFilter.Included(spawnLabels),out Vector3 pos, out Vector3 norm);
        if (hasFoundPosition)
        {
            Vector3 randomPosition = pos + norm * normalOffset;
            randomPosition.y = 0;
            Instantiate(ghostPrefab, randomPosition, Quaternion.identity);
        }
    }
}
