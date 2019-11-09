using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxeffect;
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    
    void FixedUpdate()
    {
        float tempo = (cam.transform.position.x * (1 - parallaxeffect));
        float dist = (cam.transform.position.x * -parallaxeffect);

        transform.position = new Vector2(startpos + dist, transform.position.y);
        if (tempo > startpos + length) startpos += length;
        else if (tempo < startpos - length) startpos -= length;
        
    }
}
