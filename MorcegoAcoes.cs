using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MorcegoAcoes : MonoBehaviour
{

    private bool vivo = true;
    public float distancia;
    public Transform Pep;
    public List<string> recebeDanoDe;
    public float x = 0.5f;
    public Animator animorcego;
    public CircleCollider2D damagearea;
    float cd = 1f;
    public Collider2D col;



    // Update is called once per frame
    void Update()
    {
        if (col.enabled == false)
        {
            cd -= Time.deltaTime;
        }
        if (cd < 0f)
        {
            col.enabled = true;
            cd = 1f;
        }


        distancia = Vector2.Distance(this.transform.position, Pep.transform.position);

        if (vivo == true)
        {
            if (distancia >= 12.0f)
            {
                GetComponent<AIPath>().enabled = false;
            }
            else if (distancia < 12.0f)
            {
                GetComponent<AIPath>().enabled = true;
            }
        }

        if (vivo == false)
        {



            x -= Time.deltaTime;
            if (x <= 0.0f)
            {

                Destroy(this.gameObject);

            }



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

    public void FrameDamage()
    {
        damagearea.enabled = !damagearea.enabled;
    }

}
