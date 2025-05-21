using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using Unity.AI.Navigation;
using UnityEngine;

public class RuntimeNavMeshBuilder : MonoBehaviour
{
    private NavMeshSurface navMeshSurface;
    void Start()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
        MRUK.Instance.RegisterSceneLoadedCallback(BuildNavMesh);
    }
    
    public void BuildNavMesh()
    {
        StartCoroutine(BuildNavMeshCoroutine());
    }

    public IEnumerator BuildNavMeshCoroutine()
    {
        yield return new WaitForEndOfFrame();
        navMeshSurface.BuildNavMesh();
    }
}
