using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosCenarioScripts : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.tag == "PepAttack")

        {

            this.tag = "ObjetoPlayer";

        }
        if (outro.tag == "chao")
        {
            this.tag = "chao";
        }
    }
}


        
