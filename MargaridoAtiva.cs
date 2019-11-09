using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MargaridoAtiva : MonoBehaviour
{
    public bool vivo = true;
    public bool face = true;
    public Transform Pep;
    public Transform saiTiros;
    public List<string> recebeDanoDe;
    Animator anim;
    public float distancia;
    public GameObject Prefab;
    float x = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(this.transform.position, Pep.transform.position);
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
            if (distancia <= 10)
            {
                anim.SetTrigger("Ataque");
            }
            else
            {
                anim.SetBool("Idle", true);
                anim.ResetTrigger("Ataque");
            }
            
            }if (vivo == false)
            
               
                {

                 
                    anim.SetBool("Morte", true);
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

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (recebeDanoDe.Contains(outro.tag))
        {

            vivo = false;
        }
    }

        public void FrameDamage()
        {
            Instantiate(Prefab, saiTiros.position, transform.rotation);
        }
    }

