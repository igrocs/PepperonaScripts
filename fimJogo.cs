using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fimJogo : MonoBehaviour
{
    public GameObject chefe1;
    public GameObject chefe2;
    public GameObject canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fimdejogo();
    }
    void fimdejogo()
    {
        if(chefe1 == null && chefe2 == null)
        {
            canvas.SetActive (true);
        }
    }
    
}
