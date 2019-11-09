using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour

{
    public Sprite[] HeartsSprite;
    public Image UICoracoes;
    private PlayerMovement player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    void Update()
    {
        UICoracoes.sprite = HeartsSprite[player.vidas];
}
}