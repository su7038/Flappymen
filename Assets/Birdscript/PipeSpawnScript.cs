using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnTimer = 0f;
    public float Spawninterval = 1f;
    public float Heightoffset = 3.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnpipe();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer = spawnTimer + Time.deltaTime;
        if (spawnTimer >= Spawninterval)
        {
            spawnpipe();
            spawnTimer = 0f;
        }
    }

    void spawnpipe()
    {
        float Lowestpoint= transform.position.y - Heightoffset;
        float Highestpoint = transform.position.y + Heightoffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(Lowestpoint, Highestpoint), 0), Quaternion.identity);
    }
}
