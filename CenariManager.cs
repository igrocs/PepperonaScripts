using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CenariManager : MonoBehaviour
{
    public GameObject pep;
    public Collider2D proxfase;
    public GameObject ProxFaseUI;
    public static CenariManager inst;

    public void trocaCena()
    {
        SceneManager.LoadScene(1);
     }
    
    public void continuarJogo()
    {
        SceneManager.LoadScene(1);
       
    }

    public void quitar()
    {
        Application.Quit();
    }
    public void chamaUI()
    {


        Time.timeScale = 0f;
        ProxFaseUI.SetActive(true);
    }
    
}
