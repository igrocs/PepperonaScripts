using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosDestroi : MonoBehaviour
{
    private void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.tag == "PepAttack")

        {

            this.tag = "ObjetoPlayer";

        }
        if (outro.tag =="chao")
        {
            this.tag = "chao";
        }
        if (outro.tag == "morcego")
        {
            Destroy(this.gameObject);
        }


    }
    private void OnCollisionEnter2D(Collider2D outro)
    {
        if (outro.tag == "chao")
        {
            this.tag = "chao";
        }
        if (outro.tag == "morcego")
        {
            Destroy(this.gameObject);
        }
    }
}
