using System; // Este sí lo podés dejar, aunque no es necesario
using UnityEngine;

public class Gun : MonoBehaviour
{
    public OVRInput.RawButton shootingButton;
    public LineRenderer linePrefab;
    public Transform shootingPoint;
    public float maxDistance = 100f;
    public float showTime = 0.5f;

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