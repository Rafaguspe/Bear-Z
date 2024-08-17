using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Oso : MonoBehaviour
{
    public GameObject Nube;
    private bool isShow = false;
    private bool isJump = false;
    private bool isColision = false;
    public Button JumpBoton;
    public Transform osoStop;
    public Transform osoInit;

    void Start()
    {
        JumpBoton.onClick.AddListener(() => Jump());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Abeja" && !isColision)
        {
            isColision = true;
            AudioManager.instance.PlayCrash();
            StartCoroutine(ShowNube());
            MainManager.Instance.UpdateFallas();
            StartCoroutine(UpdateCollision());
        }

    }

    private IEnumerator UpdateCollision()
    {
        yield return new WaitForSeconds(1f);
        isColision = false;
    }

    public IEnumerator ShowNube()
    {
       
        if (!isShow)
        {
            isShow = true;
            Nube.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            Nube.SetActive(false);
            isShow = false;
        }
    }


    public void Jump()
    {
        if (!isJump)
        {
            isJump = true;
            AudioManager.instance.PlayJump();
            transform.DOJump(osoStop.position, 0.1f, 1, 0.5f).OnComplete(() =>
            {
                transform.DOJump(osoInit.position, 0.1f, 1, 0.4f).OnComplete(() =>
                {
                    isJump = false;
                });
            });
        }
    }

}
