using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource audioSource;
    public AudioClip clipJump;
    public AudioClip clipCrash;
    private bool isSound;

    private void Awake()
    {
        instance = this;   
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJump()
    {
       
            isSound = true;
            audioSource.PlayOneShot(clipJump);
            //StartCoroutine(ResetSoundFlagAfterClip(clipJump.length));
        
       
    }

    public void SetSound (bool status)
    {
        isSound = status;
    }
     
    public void PlayCrash()
    {
        //isSound = true;
        audioSource.PlayOneShot(clipCrash);
        //StartCoroutine(ResetSoundFlagAfterClip(clipCrash.length));
        
    }


    private IEnumerator ResetSoundFlagAfterClip(float clipLength)
    {
        // Espera hasta que termine el clip
        yield return new WaitForSeconds(clipLength);

        // Cambia el estado a false después de que el audio haya terminado
        isSound = false;
    }
}
