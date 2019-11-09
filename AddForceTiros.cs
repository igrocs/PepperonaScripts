using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceTiros : MonoBehaviour
{
    // Start is called before the first frame update
    public float impulso;
    public Rigidbody2D ball;
    private float Duracao;
    public Transform viratiro;
    // Use this for initialization
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        ball.AddForce(new Vector2(-3, 0), ForceMode2D.Impulse);
        Duracao = 4.0f;
    }
    void Update()
    {
        Duracao -= Time.deltaTime;
        if (Duracao <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.tag == "PepAttack")

        {

            this.tag = "ObjetoPlayer";


        }

    }
}