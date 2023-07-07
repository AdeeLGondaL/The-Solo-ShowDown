using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;

    private GameObject proj;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnProjectile", 2, 4);
        Invoke("SpawnProjectile", 2);
    }

    void SpawnProjectile()
    {
        if (proj == null)
            proj = Instantiate(projectilePrefab);
    }
}
