using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider; //visualization of healthbar
    public GameObject owner; //get slider component from owner

    void Start()
    {
      slider = this.gameObject.GetComponent<Slider>();
    }
    public void setMaxHealth(int maxHP)
    {
      slider.maxValue = maxHP;
      slider.value = maxHP;
    }
    public void setHealth(int curHP)
    {
      slider.value = curHP;
    }
}
