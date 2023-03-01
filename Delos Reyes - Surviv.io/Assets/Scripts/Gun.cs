using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{//lootable item and should also appeear on player
    public bool owner;
    public Collider2D colliderComp;

    [Header ("Weapon Stats")]
    private Transform nozzle;
    public GameObject bullet;
    public float bulletSpeed;
    public int maxBulletAmt;
    public int curBulletAmt;
    public int clipCpcty;
    public int clipAmt;
    public int damage;
    public float fireRate;

    public float spread;
    public bool clipEmpty;
    public bool hold;

    [Header ("Gun Type")]
    public bool AR;
    public bool shotgun;
    public bool pistol;

    void Start()
    {
      colliderComp = GetComponent<Collider2D>();
      if (!owner)
      {
        colliderComp.enabled = true; //setting it here because fro some reason the prefabs keep turning off???
      }
      curBulletAmt = maxBulletAmt;
      clipAmt = clipCpcty;
      nozzle = transform.GetChild(0).transform;
    }
    public void Fire()
    {
      if (clipAmt > 0)
      { //shoot only if not empty
        if (pistol)
        {
          GameObject b = Instantiate(bullet, nozzle.position, nozzle.rotation);
          b.GetComponent<Rigidbody2D>().AddForce(nozzle.right *bulletSpeed);
          clipAmt--;
        }
        else if (shotgun)
        {
          float tempAngle = spread;
          for (int i = 1; i < 9; i++)
          {
            Quaternion pellets = Random.rotation;
            GameObject b = Instantiate(bullet, nozzle.position, nozzle.rotation);
            b.transform.rotation = Quaternion.RotateTowards(b.transform.rotation, pellets, tempAngle);
            b.GetComponent<Rigidbody2D>().AddForce(nozzle.right *bulletSpeed);
            tempAngle *= i;
          }
          clipAmt--;
        }
        else if (AR)
        { //still needs a keydown
          Quaternion pellet = Random.rotation;
          GameObject b = Instantiate(bullet, nozzle.position, nozzle.rotation);
          b.transform.rotation = Quaternion.RotateTowards(b.transform.rotation, pellet, spread);
          b.GetComponent<Rigidbody2D>().AddForce(nozzle.right *bulletSpeed);
          clipAmt--;
        }
      }
      else Reload();
    }
    public void Reload()
    {
      if (curBulletAmt > 0)
      {
        if (curBulletAmt >= clipCpcty)
        {
            clipAmt += clipCpcty;
            curBulletAmt -= clipCpcty;
        }
        else
        {
            clipAmt += curBulletAmt; //give everything
            curBulletAmt -= curBulletAmt;
        }
      }
      else Debug.Log("No more bullets!");
    }

    public void StopFiring() //for AI use
    {
      CancelInvoke("Fire");
    }

    public void StartFiring() //for AI use
    {
      InvokeRepeating("Fire", fireRate, fireRate);
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
      if (collider.tag == "Opponents")
      {
        Unit uScript = collider.gameObject.GetComponent<Unit>();
        if (AR || shotgun)
        {
          if (!uScript.primOcc)
          {
            this.gameObject.transform.position = new Vector2(0,0); //resets it so thats its realtive to parent's tranasform
            this.gameObject.transform.SetParent(uScript.primarySlot.transform, false);
          }
          else 
          {
            Destroy(uScript.primarySlot.transform.GetChild(0).gameObject); //destroy the first one
            this.gameObject.transform.position = new Vector2(0,0);
            this.gameObject.transform.SetParent(uScript.primarySlot.transform, false);
          }
        }
        else if (pistol)
        {
          if (!uScript.secOcc)
          {
            this.gameObject.transform.position = new Vector2(0,0);
            this.gameObject.transform.SetParent(uScript.secondarySlot.transform, false);
          }
          else 
          {
            Destroy(uScript.secondarySlot.transform.GetChild(0).gameObject); //destroy the first one
            this.gameObject.transform.position = new Vector2(0,0);
            this.gameObject.transform.SetParent(uScript.secondarySlot.transform, false);
          }
        }
        colliderComp.enabled = false; //turn it off after pickup
      }
    }
}
