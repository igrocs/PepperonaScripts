using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPep : MonoBehaviour {
    /* face troca o lado que o personagem olha, PersRB é o rigidbody do personagem
     */
    public bool face = true;
    public Transform perstransform;
    public float vel = 2.5f;
    public float force = 6.5f;
    public Rigidbody2D PersRB;

    public bool pular = false ;
    public Transform check;
    public LayerMask verifchao;
    public float raio = 0.2f;

    public bool dano = false;
    public Animator anim;
    public bool vivo = true;
    public float conta1 = 0.5f;
    public float conta2 = 2.0f;
    
	void Start () {
        perstransform = GetComponent<Transform>();
        PersRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() 
{
        if (vivo == true)
        {//comandos e flips
            if (Input.GetKey(KeyCode.RightArrow) && !face)
            {
                Flip();
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && face)
            {
                Flip();
            }
            //verifica chao

            pular = Physics2D.OverlapCircle(check.position, raio, verifchao);
        }
        if (dano == true)
        {
            
            conta2 = 2.0f;
            conta1 -= Time.deltaTime;

        }
        if (conta1 <= 0)
        {
            conta2 -= Time.deltaTime;
            dano = false;
            if (conta2 <= 0)
            {
                conta1 = 1.0f;
                

            }
        }
    if (vivo == false)
            {
                anim.SetBool("Morte", true);
                anim.SetBool("Andar", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Pulo", false);
                anim.SetBool("PuloSoco", false);
                anim.SetBool("Dano", false);
              
            }

        if (vivo ==true)
        { 

            if (Input.GetKey(KeyCode.RightArrow) && dano == false)
            {
                transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                andar();
               
            }
           else  if (Input.GetKey(KeyCode.LeftArrow) && dano == false)
            {
                transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
                andar();
            }
            else 
            {
                idle();
            }
            if (Input.GetKeyDown(KeyCode.Space) && pular == true && dano == false)
            {
                PersRB.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
                pulo();
            }
            if (Input.GetKeyDown(KeyCode.Space) && pular == true)
            {
               
                
                if (pular == false && dano == false)
            { PersRB.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
                pulo();
            }
            }
        


            
           
            
            

           

        }
    }
    void Flip ()
    {
        face = !face;
        Vector3 scala = perstransform.localScale;
        scala.x *= -1;
        perstransform.localScale = scala;
    }
    private void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("chao"))
        {
           
            anim.SetBool("Pulo", false);
            anim.SetBool("Idle", true);
            anim.SetBool("Andar", false);
        }
    }
        
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("damage")) 
        {

            vivo = false;
            
        }
      

    }
    void andar()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Andar", true);
        anim.SetBool("Pulo", false);
        anim.SetBool("Dano", false);
    }
    void idle()
    {
        anim.SetBool("Dano", false);
        anim.SetBool("Idle", true);
        anim.SetBool("Andar", false);
        anim.SetBool("Pulo", false);
    }
    void pulo()
    {
        anim.SetBool("Dano", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Andar", false); 
        anim.SetBool("Pulo", true);
    }
  void sofredano()
    {
        dano = true;
        anim.SetBool("Andar", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Pulo", false);
        anim.SetBool("PuloSoco", false);
        anim.SetBool("Dano", true);
    }
    void morte()
    {
        anim.SetBool("Andar", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Pulo", false);
        anim.SetBool("PuloSoco", false);
        anim.SetBool("Dano", false);
        anim.SetBool("Morte", true);


    }


}
