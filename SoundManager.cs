using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;   //Efeitos sonoros
    public AudioSource musicSource; //Musica de fundo
    public static SoundManager instance = null; //
    public float lowPitchRange = .95f;  //Picth mais baixo do som
    public float highPitchRange = 1.05f;    //Picth mais alto do som


    void Awake()
    {
     if (instance == null)
        {
            instance = this;
        } else if(instance != this){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle (AudioClip clip)
    {
        efxSource.clip = clip;

        efxSource.Play();
    }

    public void RamdomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        efxSource.pitch = randomPitch;
        efxSource.clip = clips [randomIndex];
        efxSource.Play();
    }
}
