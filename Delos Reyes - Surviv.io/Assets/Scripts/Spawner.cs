using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  [Header ("obstacles")]
    public GameObject[] obstacles; //environment
    public GameObject obstacle;
    public int obstacleAmt;

    [Header ("Guns")]
    public GameObject[] guns; //weapon
    public GameObject gun;
    public int gunAmt;

    [Header ("Ammos")]
    public GameObject[] ammos; //lootables
    public GameObject ammo;
    public int ammoAmt;

    [Header ("Opponents")]
    public GameObject[] enemies; //lootables
    public GameObject enemy;
    public int enemyAmt;

    //position range of where it can spawn(?)
    [Header ("Spawn Range")]
    private float maxY = 24;
    private float minY = -24;
    private float maxX = 44;
    private float minX = -44;

    private float randomX;
    private float randomY;

    // Start is called before the first frame update
    void Start()
    {
      Spawn(obstacles, obstacle, obstacleAmt);
      Spawn(guns, gun, gunAmt);
      Spawn(ammos, ammo, ammoAmt);
      Spawn(enemies, enemy, enemyAmt);
    }
    void Spawn(GameObject[] arrays, GameObject array, int amount)
    {

      for (var i = 0; i < amount; i++)
      { //loop accdg to how many u want in the scene
        array = arrays[Random.Range(0, arrays.Length)]; //randomize which item from the list is assigned
        Randomize();
        Instantiate(array, transform.position + new Vector3(randomX,randomY, 0), transform.rotation);
      }
    }
    void Randomize()
    {
        randomY = Random.Range(minY, maxY);
        randomX = Random.Range(minX, maxX);
        //timeBetwSpawn = Random.Range(minTRange * mult, maxTRange * mult);
    }
}
