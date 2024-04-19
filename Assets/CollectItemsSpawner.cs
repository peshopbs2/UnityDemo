using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemsSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float spawnTime = 5f;
    private int spheres = 0;
    public int Spheres
    {
        get { return spheres; }
    }

    private Vector3 spawnValues = new Vector3(20.0f, 0.5f, 20.0f);

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);   
    }

    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnValues.x, spawnValues.x),
            spawnValues.y,
            Random.Range(-spawnValues.z, spawnValues.z)
        );
        Instantiate( prefab, spawnPosition + transform.position, Quaternion.identity);
        IncreaseSpheres();
    }

    public void IncreaseSpheres()
    {
        spheres++;
    }

    public void DecreaseSpheres()
    {
        spheres--;
    }
}
