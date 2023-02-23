using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnObsts : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject obstacle;
    PlayerMovement pScript;

    public float maxY;
    public float minY;
    public float maxTRange;
    public float minTRange;
    public float timeBetwSpawn;
    public float maxTime; //max smallest value of time spawning for when levels get more difficult and multipliers are added
    private float spawnTime;
    void Start()
    {
      obstacle = obstacles[Random.Range(0, obstacles.Length)];
      pScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<PlayerMovement>();

      if(pScript.medium)
      {
        maxTRange *= 0.75f;
        minTRange *= 0.75f;
      }
      else if(pScript.hard)
      {
        maxTRange *= 0.5f;
        minTRange *= 0.5f;
      }
    }

    void Update()
    {
      if(!pScript.powersurge)
      {
        Randomize(1);
        if(Time.time > spawnTime)
        {
          Spawn();
          spawnTime = Time.time + timeBetwSpawn;
        }
      }
      else{
        Randomize(0.5f);
        if(Time.time > spawnTime){
          Spawn();
          spawnTime = Time.time + timeBetwSpawn;
        }
      }
    }
    void Spawn()
    {
      float randomY = Random.Range(minY, maxY);

      Instantiate(obstacle, transform.position + new Vector3(0, randomY, 0), transform.rotation);
    }

    void Randomize(float mult){
        obstacle = obstacles[Random.Range(0, obstacles.Length - 1)];
        timeBetwSpawn = Random.Range(minTRange * mult, maxTRange * mult);
    }
}
