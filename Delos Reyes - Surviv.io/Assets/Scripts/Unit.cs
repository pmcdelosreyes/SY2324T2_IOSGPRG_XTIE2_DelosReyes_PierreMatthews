using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
  [Header ("Unit Stats")]
  public float speed = 3f;
  private float  maxHP = 100;
  public float curHP;
  public bool isPlayer;
  public bool isAI;

  [Header ("Equipment")]
  public GameObject[] weapons; //choices for randomizing for loadout
  public GameObject primarySlot; //slots for weapons
  public GameObject secondarySlot;
  public int ARsupply; //3 categories: shotgun, ar, pistol
  public int SGsupply;
  public int PTsupply;

  public bool primOcc; //is primary occupied
  public bool secOcc; //is secondary occupied
  public bool primActive = true;
  public bool secActive = false;
    public float GetMaxHP(){ return maxHP;}

    public void SetPrimWeapon()
    {
      GameObject gunPrefab = weapons[Random.Range(0,2)];
      GameObject gun = Instantiate(gunPrefab);
      gun.transform.SetParent(primarySlot.transform, false);
      gun.GetComponent<Collider2D>().enabled = false;
      gun.GetComponent<Gun>().owner = true;
    }
    public void SetSecWeapon()
    {
      GameObject gunPrefab = weapons[2];
      GameObject gun = Instantiate(gunPrefab);
      gun.transform.SetParent(secondarySlot.transform, false);
      gun.GetComponent<Collider2D>().enabled = false;
      gun.GetComponent<Gun>().owner = true;
      secondarySlot.SetActive(false); //hide while not active
    }
}
