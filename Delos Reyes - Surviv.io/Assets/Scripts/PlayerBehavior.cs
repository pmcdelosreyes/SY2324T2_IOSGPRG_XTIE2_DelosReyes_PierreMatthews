using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerBehavior : Unit
{

    [Header ("UI")]
    public Joystick rightDpad;
    public Joystick leftDpad;
    public GameObject pIndicator;
    public GameObject sIndicator;
    public GameObject arInfo;
    public GameObject sgInfo;
    public GameObject activeBulletText;
    public GameObject activeClipText;

    [Header ("Player Components")]
    private Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 aimPos;

    // Start is called before the first frame update
    void Start()
    {
      curHP = GetMaxHP();
      rb = GetComponent<Rigidbody2D>();
      SetPrimWeapon();
      SetSecWeapon();
    }

    // Update is called once per frame
    void Update()
    {
      movement.x = leftDpad.Horizontal * speed;
      movement.y = leftDpad.Vertical * speed;
      aimPos.x = rightDpad.Horizontal * speed;
      aimPos.y = rightDpad.Vertical * speed;
      WhatPrimGun();
      UpdateBulletTexts();
    }

    void FixedUpdate()
    {
      //Joystick method
      rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
      float angle = Mathf.Atan2(aimPos.y, aimPos.x)*Mathf.Rad2Deg;
      rb.rotation = angle;

    }
    public void SwitchWeapon()
    {
      if (primActive)
      {
        primActive = !primActive;
        sIndicator.SetActive(true);
        secondarySlot.SetActive(true);
        pIndicator.SetActive(false);
        primarySlot.SetActive(false);
        secActive = !secActive;
      }
      else if (secActive)
      {
        primActive = !primActive;
        primarySlot.SetActive(true);
        pIndicator.SetActive(true);
        sIndicator.SetActive(false);
        secondarySlot.SetActive(false);
        secActive = !secActive;
      }
    }
    public void Shoot()
    {
      if (primActive)
      {
        primarySlot.transform.GetChild(0).GetComponent<Gun>().Fire();
      }
      else
      {
        secondarySlot.transform.GetChild(0).GetComponent<Gun>().Fire();
      }
    }
    private void WhatPrimGun()
    {
      if (primarySlot.transform.GetChild(0).GetComponent<Gun>().AR)
      {
        arInfo.SetActive(true);
        sgInfo.SetActive(false);
      }
      else if (primarySlot.transform.GetChild(0).GetComponent<Gun>().shotgun)
      {
        sgInfo.SetActive(true);
        arInfo.SetActive(false);
      }
    }
    private void UpdateBulletTexts()
    { //just to update ui texts
      if (primActive)
      {
        activeBulletText.GetComponent<Text>().text = primarySlot.transform.GetChild(0).GetComponent<Gun>().curBulletAmt.ToString();
        activeClipText.GetComponent<Text>().text = primarySlot.transform.GetChild(0).GetComponent<Gun>().clipAmt.ToString();
      }
      else
      {
        activeBulletText.GetComponent<Text>().text = secondarySlot.transform.GetChild(0).GetComponent<Gun>().curBulletAmt.ToString();
        activeClipText.GetComponent<Text>().text = secondarySlot.transform.GetChild(0).GetComponent<Gun>().clipAmt.ToString();
      }
    }
}
