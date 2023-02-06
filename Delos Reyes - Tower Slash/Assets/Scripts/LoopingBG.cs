using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBG : MonoBehaviour
{
    public float speed;
    public Renderer bgRender;

    void Start(){
      bgRender = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        bgRender.material.mainTextureOffset += new Vector2(0f,speed * Time.deltaTime);
    }
}
