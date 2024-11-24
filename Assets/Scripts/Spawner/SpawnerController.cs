using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject prefabToInstantiate;
    [SerializeField] private float radio;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnCount;
    [SerializeField] private float timer = 0;


    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            Debug.Log(spawnCount);

            StartCoroutine(SpawnObject(spawnCount));

            timer = 0;

        }
    }

    private IEnumerator SpawnObject(float spawnCount)
    {
        
            Bounds limits = GetComponent<BoxCollider2D>().bounds;

            for (int i = 0; i < spawnCount; i++)
            {
                float x = Random.Range(limits.min.x, limits.max.x);
                float y = Random.Range(limits.min.y, limits.max.y);

                Vector3 spawn = new Vector3(x, y);

                GameObject gameObject = Instantiate(prefabToInstantiate, spawn, Quaternion.identity);

                yield return new WaitForSeconds(0.1f);
            }
        
        yield return new WaitForSeconds(0.1f);
    }

    
}