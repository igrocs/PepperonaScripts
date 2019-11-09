using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controlador;
    public Animator anim;
    float veloc = 40f;
    float MoveLateral = 0f;
    bool pulo = false;
    public CircleCollider2D colliderSoco;
    public List<string> recebeDanoDe;
    public bool vivo = true;
    float i = 2.0f;
    public float cooldown = 0;
    public bool chao = false;
    public int vidas = 4;
    public ParticleSystem Poeira;
    public AudioSource moveSound1;    //audio de movimento 
    public AudioSource moveSound2;    //audio de soco
    public AudioSource moveSound3;    //audio de dano
    public AudioSource puloSound;     //audio de pulo
    public AudioSource gameOverSound;     //audio da derrota
    public GameObject efeitoCorrente;
    public GameObject efetoCorrentequebro;
    // Update is called once per frame
    void Update()

    {
        //anda
        if (vivo == true)
        {
            MoveLateral = Input.GetAxis("Horizontal") * veloc;

            anim.SetFloat("anda", Mathf.Abs(MoveLateral));
            anim.ResetTrigger("Ataque");

            anim.ResetTrigger("PULOSOCO");

            if (MoveLateral < 0.9 && MoveLateral > 0)
            {
                CriarPoeira();
            }
            if (MoveLateral > -0.9 && MoveLateral < 0)
            {
                CriarPoeira();
            }
            if (chao == true)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) )
                {
                    moveSound1.Play();

                }
                moveSound1.UnPause();
            }
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
                {
                    moveSound1.Stop();
                }
                if (chao == false)
                moveSound1.Pause();




            //pula
            if (Input.GetButtonDown("Jump"))
            {if (chao == true)
                {
                    CriarPoeira();
                }
                chao = false;
                pulo = true;
                anim.SetBool("Pulo", true);
                anim.ResetTrigger("Ataque");
                anim.ResetTrigger("PULOSOCO");
            }


            
            //golpear
            if (Input.GetButton("Attack"))
            {

                if (chao == true)
                {
                    anim.ResetTrigger("PULOSOCO");
                    anim.SetTrigger("Ataque");
                    moveSound2.Play();

                }
                if (chao == false)
                {
                    anim.SetTrigger("PULOSOCO");
                    anim.ResetTrigger("Ataque");
                    moveSound2.Play();
                }

            }

         

        }

        else
        {
            anim.SetBool("Morte", true);
        }
        if (vivo == false)
        {
            i -= Time.deltaTime;
            if (i <= 0.0f)
            {
                SceneManager.LoadScene(0);
            }
        }
       /* if (vidas <= 0)
        {
            anim.SetBool("Morte", true);
            vivo = false;
        }*/
    
    } 

    //funções
    private void OnCollisionEnter2D(Collision2D outro)
    {//verifica se esta no chao ou na plataforma
        if (outro.gameObject.CompareTag("chao") || outro.gameObject.CompareTag("ObjetoPlayer")) 
        {

            anim.SetBool("Pulo", false);
            anim.SetBool("PuloSoco", true);
            chao = true;

            
        }
        else if (outro.gameObject.CompareTag("plataforma"))
        {

            anim.SetBool("Pulo", false);
            anim.SetBool("PuloSoco", true);
            chao = true;
           

        }


    }

    //collider do soco 
    public void Soco()
    {
        colliderSoco.enabled = !colliderSoco.enabled;
        //tlvz usar dps colliderSoco.enabled = false;
    }
    public void SocoAr()
    {
        colliderSoco.enabled = true;
    }
    public void SocoArSai()
    {
        colliderSoco.enabled = false;
    }


    private void FixedUpdate()
    {
        controlador.Move(MoveLateral * Time.fixedDeltaTime, false, pulo);
        pulo = false;
    }
    //dano
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.tag == "coracao")
        {
            vidas += 1;
        }
        
        if (recebeDanoDe.Contains(outro.tag) && cooldown <=0)
        
        {
           
            anim.SetTrigger("Dano");
            vidas -= 1;
          if (outro.tag == "zonamorte")
            {
               
                vidas -= vidas;
                vivo = false;
            }

            if (outro.gameObject.CompareTag("corrente"))
            {
                Instantiate(efeitoCorrente, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
                Destroy(outro.gameObject);
            }
            if (outro.gameObject.CompareTag("corrente"))
            {
                Instantiate(efetoCorrentequebro, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
                Destroy(outro.gameObject);
            }
        }


    }
    void CriarPoeira()
    {
        
        Poeira.Play();
    }
    void naotomadano()
    {
        int vidasatual = vidas;
        vidas = vidasatual;
    }

    

}
