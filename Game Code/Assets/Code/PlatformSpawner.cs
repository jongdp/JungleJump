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
    /// Max time allowed for there not to be a banana (i.e., spawns a banana if
    /// there has not been a banana that has spawned in this amount of time).
    /// </summary>
    public float BananaInterval = 1.5f;

    /// <summary>
    /// The next time at which spawning is allowed, based on Unity's Time.time.
    /// </summary>
    public float NextSpawn = 0;

    /// <summary>
    /// The next time at which spawning a banana is recommended, based on Unity's Time.time.
    /// </summary>
    public float BananaSpawn = 0;

    /// <summary>
    /// Stores the latest randomly generated spawn location.
    /// Primarily used for platform positioning.
    /// </summary>
    public Vector3 randLoc;

    /// <summary>
    /// Unity's update loop, called once per frame.
    /// Checks whether it's time to spawn a new platform (and maybe a banana),
    /// then instantiates objects with randomized properties and movement.
    /// Note: Used Vector3 because Unity expexcts a Vector3 when instantiating.
    /// </summary>
    void Update()
    {
        if (Time.time >= NextSpawn)
        {
            var platformLoc = randomLocation();
            var bananaLoc = platformLoc;
            var bananay = platformLoc.y +0.5f;
            bananaLoc.y = bananay;

            var platform = Instantiate(randomPlatform(), platformLoc, Quaternion.identity);
            platform.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
            if (spawnBanana() || Time.time >= BananaSpawn)
            {
                var banana = Instantiate(bananaPrefab, bananaLoc, Quaternion.identity);
                banana.GetComponent<Rigidbody2D>().velocity = new Vector2(-7, 0);
                BananaSpawn += BananaInterval;
            }

            NextSpawn += SpawnInterval;

        }

    }

    /// <summary>
    /// Generates a random vertical spawn position for the next platform,
    /// while keeping the horizontal (X) position constant off-screen to the right.
    /// </summary>
    /// <returns>A Vector3 representing the spawn location.</returns>
    public Vector3 randomLocation()
    {
        var val = Random.Range(-4, 2);
        randLoc = new Vector3(8.85f, val, 0);
        return randLoc;
    }

    /// <summary>
    /// Randomly selects one of the two platform prefabs to instantiate.
    /// </summary>
    /// <returns>A GameObject representing the selected platform prefab.</returns>
    public GameObject randomPlatform()
    {
        int val = Random.Range(0,2);
        if (val == 1)
            return platform1Prefab;
        return platform2Prefab;
    }

    /// <summary>
    /// Randomly determines whether to spawn a banana on this spawn cycle.
    /// Used to introduce variation and scarcity in collectibles.
    /// </summary>
    /// <returns>True if a banana should be spawned; false otherwise.</returns>
    public bool spawnBanana()
    {
        int val = Random.Range(0, 3);
        if (val == 1)
            return true;
        return false;
    }

}