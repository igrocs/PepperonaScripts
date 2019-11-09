using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topera : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
    bool vivo = true;
    public List<string> recebeDanoDe;
    public Collider2D col;
     float cd = 1f;

    Vector3 nextPos;
    // Use this for initialization
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(col.enabled == false)
        {
            cd -= Time.deltaTime;
        }
        if (cd < 0f)
        {
            col.enabled = true;
            cd = 1f;
        }
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    if (vivo == false)
        {
            Destroy(this.gameObject);
        }
    }

   
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (recebeDanoDe.Contains(outro.tag))
        {
            vivo = false;
        }
     
        if (outro.tag == "Player")
        {
            col.enabled = false;
        }
        
    }
}
