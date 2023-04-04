using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : Unit
{
    public float spotRadius;
    private float closeness;
    public bool isSpotted;
    private float wanderCloseness = 25;
    private float maxY = 24;
    private float maxX = 44;
    Vector2 waypoint;
    [Header ("Enemy Stats")]
    private Rigidbody2D rb;
    public Animator anim;
    private Vector2 movement;
    public GameObject[] opponents;
    public GameObject nearestOpp;
    public GameObject[] GetOpponents() {return opponents;}

    void Start()
    {
      opponents = GameObject.FindGameObjectsWithTag("Opponents");
      rb = this.GetComponent<Rigidbody2D>();
      anim = this.GetComponent<Animator>();
      curHP = GetMaxHP();
      SetPrimWeapon();
      SetSecWeapon();
      SetNewDestination();
    }
    void Update()
    {
      Nearby();
    }

    void FixedUpdate()
    {
      if (isSpotted)
      {
          Chase(movement, closeness);
          if (closeness > 2)
          {
                Shoot();
                isSpotted = false;
          }
      }
      else Wander();
    }

    void Nearby()
    {
      foreach (GameObject o in opponents)
      {
          Vector2 lookDir = ((Vector2)o.transform.position - rb.position);
          float distance = Vector2.Distance(transform.position, o.transform.position);
          float angle = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg +90f;
          rb.rotation = angle;

          if (distance < spotRadius)
            {
                nearestOpp = o;
                movement = lookDir;
                closeness = distance;
                isSpotted = true;
          }
          else 
          {
              nearestOpp = null;
          }
        }
    }
    void SetNewDestination()
    {
      waypoint = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));
    }
    void Wander()
    {
      transform.position = Vector2.MoveTowards(transform.position, waypoint, speed*Time.deltaTime);
      if (Vector2.Distance(transform.position, waypoint) < wanderCloseness)
      {
        SetNewDestination();
      }
      Debug.Log("is roaming...");
    }
    void Chase(Vector2 direction, float distance)
    {
      rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void Shoot()
    {
      if (primActive)
      {
        primarySlot.transform.GetChild(0).GetComponent<Gun>().StartFiring();
      }
      else
      {
        secondarySlot.transform.GetChild(0).GetComponent<Gun>().StartFiring();
      }
    }
}
