using System;
using GhostCharacter_Free.Scripts; // Este sí lo podés dejar, aunque no es necesario
using UnityEngine;

public class Gun : MonoBehaviour
{
    public OVRInput.RawButton shootingButton;
    public LineRenderer linePrefab;
    public Transform shootingPoint;
    public float maxDistance = 100f;
    public float showTime = 0.2f;
    
    public GameObject rayImpactPrefab;

    public LayerMask layerMask;

    private void Update()
    {
        if (OVRInput.GetDown(shootingButton))
        {
            Debug.Log("Shoot");
            Shoot();
        }
    }

    private void Shoot()
    {
        Ray ray = new Ray(shootingPoint.position, shootingPoint.forward);
        bool  hasHit = Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask);
        Vector3 endPoint = hit.point;
        if (hasHit)
        {
            endPoint = hit.point;
            GhostMove ghost = hit.transform.gameObject.GetComponentInParent<GhostMove>();

            if (ghost != null)
            {
                //Kill ghost
                hit.collider.enabled = false;
                ghost.Kill();
            }
            else
            {
                Debug.Log("Hit" + hit.transform.name);
                Quaternion rayImpactRotation = Quaternion.LookRotation(hit.normal);
                GameObject rayImpact = Instantiate(rayImpactPrefab, hit.point, rayImpactRotation);
                Destroy(rayImpact, 1f);    
            }
            
            
        }
        else
        {
            endPoint = shootingPoint.position + shootingPoint.forward * maxDistance;
        }
        Vector3 start = shootingPoint.position;
        Vector3 end = start + shootingPoint.forward * maxDistance;

        // Instanciar el prefab de línea
        LineRenderer lineInstance = Instantiate(linePrefab);

        // Configurar puntos del LineRenderer
        lineInstance.SetPosition(0, start);
        lineInstance.SetPosition(1, end);

        // Destruir luego del tiempo indicado
        Destroy(lineInstance.gameObject, showTime);
    }
}