using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abeja : MonoBehaviour
{
    private bool point = true;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameObject finishObject = GameObject.FindGameObjectWithTag("Finish");
        StartCoroutine(PlaySound());

        if (finishObject != null)
        {
            // Obtén la posición en el eje X del objeto con el tag "finish"
            float targetX = finishObject.transform.position.x;
            int time = Random.Range(4, 8);

            // Mueve el objeto actual a la posición X del objeto con el tag "finish" en 5 segundos
            transform.DOMoveX(targetX, time).OnComplete(() =>
            {
               
            });
        }


    }

    private IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(1f);
        audioSource.Play();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            point = false;
        }

        if (other.gameObject.tag == "Finish")
        {
            StartCoroutine(Destroy());
        }

    }


    private IEnumerator Destroy()
    {
        if (point)
        {
            MainManager.Instance.UpdatePuntos();
        }

        yield return new WaitUntil(() => !audioSource.isPlaying);
        Destroy(gameObject);
    }
  
}
