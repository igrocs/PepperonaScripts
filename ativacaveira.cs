using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativacaveira : MonoBehaviour
{
    public float vel = 3.0f;
    public bool ativaGoblin = false;
    public float distancia;
    public Transform Pep;
    public bool face = true;
    public float conta = 0.3f;
    public AudioSource goblinAnda;

    public List<string> recebeDanoDe;
    Animator animagoblin;

    public bool ataqueGoblin = false;
    public CircleCollider2D damagearea;
    bool vivo = true;
    public float x = 0.5f;
    public float distanciaAtiva;


    void Start()
    {
        animagoblin = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()

    {//guarda a distancia do goblin pro player
        distancia = Vector2.Distance(this.transform.position, Pep.transform.position);


        //flipa goblin
        if (vivo == true)
        {
            if ((Pep.transform.position.x > this.transform.position.x) && face)
            {
                flip();
            }
            else if ((Pep.transform.position.x < this.transform.position.x) && !face)
            {
                flip();

            }
        }
        //atacar
        if (vivo == true)
        {
            if (distancia <= 3.5f)
            {
                conta -= Time.deltaTime;
                if (conta <= 0)
                {
                    animagoblin.SetTrigger("Ataca");
                    conta = 0.8f;
                }
            }
            if (distancia > 3.5f)
            {
                conta = 0.3f;
            }

        }
        else
        {
            animagoblin.SetBool("Idle", true);
        }

        if (distancia <= distanciaAtiva)
        {
            ativaGoblin = true;
        }
        else if (distancia > distanciaAtiva)
        {
            ativaGoblin = false;
        }
        //trigger para perseguir  
        if (vivo == true)
        {

            if (ativaGoblin == false)
            {
                animagoblin.SetBool("Anda", false);
                animagoblin.SetBool("Idle", true);
            }


        }
        if ((ativaGoblin == true) && ataqueGoblin == false)
        {

            if (Pep.transform.position.x < this.transform.position.x)
            {
                transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
                animagoblin.SetBool("Anda", true);
                animagoblin.SetBool("Idle", false);

            }
            else if (Pep.transform.position.x > this.transform.position.x)
            {
                transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                animagoblin.SetBool("Anda", true);
                animagoblin.SetBool("Idle", false);

            }








        }
        if (vivo == false)
        {

            damagearea.enabled = false;
            animagoblin.SetBool("Morte", true);
            x -= Time.deltaTime;
            if (x <= 0.0f)
            {
                Destroy(this.gameObject);

            }


        }


    }
    void flip()
    {
        face = !face;
        Vector3 scala = this.transform.localScale;
        scala.x *= -1;
        this.transform.localScale = scala;
    }
    public void FrameDamage()
    {
        damagearea.enabled = !damagearea.enabled;
    }
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (recebeDanoDe.Contains(outro.tag))
        {

            vivo = false;

        }


        if (outro.gameObject.CompareTag("goblin"))
        {
            Instantiate(goblinAnda, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
            Destroy(outro.gameObject);
        }


    }
}
