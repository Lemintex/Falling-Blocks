using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject fallingBlock;

    float timeToSpawn;

    float minTimeBetweenSpawns = 0.6f, maxTimeBetweenSpawns = 1.5f;
    float halfScreenHeight, halfScreenWidth;

    float minSize = 0.5f, maxSize = 2;
    float angle = 12.5f;

    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = Time.time;
        halfScreenHeight = Camera.main.orthographicSize;
        halfScreenWidth = halfScreenHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToSpawn < Time.time)
        {
            float timeBetweenSpawns = Mathf.Lerp(maxTimeBetweenSpawns, minTimeBetweenSpawns, Difficulty.GetDifficulty());
            timeToSpawn = Time.time + timeBetweenSpawns;
            float size = Random.Range(minSize, maxSize);
            Vector2 position = new Vector2(Random.Range(-halfScreenWidth, halfScreenWidth), halfScreenHeight + (size / 2));
            GameObject block = (GameObject)Instantiate(fallingBlock, position, Quaternion.identity);
            block.transform.localScale = Vector3.one * size;
            block.transform.rotation = Quaternion.Euler(0, 0, Random.Range(angle, -angle));
        }
    }
}
