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



    //public GameObject prefab;
    //public float spawnRate;
    //public float spawnDelay = 3f;

    private void OnEnable()
    {
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
        //spawnRate = Random.Range(0, 4);
        //GameObject obstacle = Instantiate(prefab, transform.position, Quaternion.identity);

        float spawnChance = Random.value;
        foreach (var obj in objects)
        {
            if (spawnChance < obj.spawnChance)
            {
                GameObject obstacle = Instantiate(obj.prefab_1, transform.position, Quaternion.identity);
                //obstacle.transform.position += transform.position;
                break;
            }

            spawnChance -= obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

}
