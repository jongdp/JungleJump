using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /// <summary>
    /// Getting the necessary prefabs
    /// </summary>
    public GameObject platform1Prefab;
    public GameObject platform2Prefab;
    public GameObject bananaPrefab;


    /// <summary>
    /// Seconds between spawn operations
    /// </summary>
    public float SpawnInterval = 1.5f;

    /// <summary>
    /// Gives the next time interval of when an enemy should spawn
    /// </summary>
    public float NextSpawn = 0;

    /// <summary>
    /// Gives the next time interval of when an enemy should spawn
    /// </summary>
    public Vector3 randLoc;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= NextSpawn)
        {
            var platformLoc = randomLocation();
            var bananaLoc = platformLoc;
            var y = platformLoc.y +0.5f;
            bananaLoc.y = y;

            var platform = Instantiate(randomPlatform(), platformLoc, Quaternion.identity);
            platform.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
            if (spawnBanana())
            {
                var banana = Instantiate(bananaPrefab, bananaLoc, Quaternion.identity);
                banana.GetComponent<Rigidbody2D>().velocity = new Vector2(-7, 0);
            }

            NextSpawn += SpawnInterval;
        }

    }


    public Vector3 randomLocation()
    {
        var val = Random.Range(-4, 2);
        randLoc = new Vector3(8.85f, val, 0);
        return randLoc;
    }

    public GameObject randomPlatform()
    {
        int val = Random.Range(0,2);
        if (val == 1)
            return platform1Prefab;
        return platform2Prefab;
    }

    public bool spawnBanana()
    {
        int val = Random.Range(0, 2);
        if (val == 1)
            return true;
        return false;
    }

}