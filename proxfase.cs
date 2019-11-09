using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class proxfase : MonoBehaviour
{

    public GameObject ProxFaseUI;


   private void OnTriggerEnter2D (Collider2D outro)
    {
        if (outro.tag == "Player")
        {

            Time.timeScale = 0f;
            ProxFaseUI.SetActive(true);
        }
    }


    public void prox()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;

    }
    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
