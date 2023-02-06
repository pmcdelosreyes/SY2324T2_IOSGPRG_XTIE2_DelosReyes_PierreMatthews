using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    [Header ("Minions")]
    GameObject[] minions;

    [Header ("Boss Stats")]
    public float iniSpeed = 3f;
    public float speed;
    public Transform boss;
    private Rigidbody2D rb;
    private Vector2 bossDirection;

    public float scoreQuota = 5000;

    // Start is called before the first frame update
    void Start()
    {
        boss = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        speed = iniSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        rb.velocity = new Vector2(0, bossDirection.y* speed);
    }
}
