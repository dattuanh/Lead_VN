using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab_1;
        [Range(0f, 1f)]
        public float spawnChance;
    }
    public SpawnableObject[] objects;
    //how often we want the object to spawn
    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    public GameObject finishingPointPrefab;
    public float spawnDuration = 30f; // duration in seconds after which the finishing point will be spawned

    private bool stopSpawning = false;


    private void OnEnable()
    {
        StartCoroutine(SpawnFinishingPointAfterDuration(spawnDuration));

        //InvokeRepeating(nameof(Spawn), spawnRate, spawnDelay);
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable()
    {
        //CancelInvoke(nameof(Spawn));
        CancelInvoke();
    }

    private void Spawn()
    {
        if (stopSpawning) return;
        //spawnRate = Random.Range(0, 4);
        //GameObject obstacle = Instantiate(prefab, transform.position, Quaternion.identity);

        float spawnChance = Random.value;
        foreach (var obj in objects)
        {
            if (spawnChance < obj.spawnChance)
            {
                GameObject obstacle = Instantiate(obj.prefab_1, transform.position, Quaternion.identity);
                break;
            }

            spawnChance -= obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private IEnumerator SpawnFinishingPointAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        stopSpawning = true;

        Vector3 finishingPointPosition = new Vector3(14.0568f, -2.3668f, -1f);
        Instantiate(finishingPointPrefab, finishingPointPosition, Quaternion.identity);
    }

}
