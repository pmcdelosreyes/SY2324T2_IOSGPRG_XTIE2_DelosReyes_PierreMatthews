using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  private GameObject player;

  public bool isFollowing;

  public float xOffset;
  public float yOffset;
    void Start ()
    {
        player = GameObject.Find("player");
        isFollowing = true;
    }
    void Update ()
    {
        if (isFollowing) transform.position = new Vector3(player.transform.position.x + 
                  xOffset, player.transform.position.y + yOffset, transform.position.z);
    }
}
