using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Button returnButton;
    public TextMeshProUGUI puntosText;
    public TextMeshProUGUI fallosText;
    public int puntos;
    public int fallos;
  

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        returnButton.onClick.AddListener(() => SceneManager.LoadScene(0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdatePuntos()
    {
        puntos++;
        UpdateText();
    }

    public void UpdateFallas()
    {
        fallos++;
        UpdateText();
    }

    private void UpdateText()
    {
        puntosText.text = puntos.ToString();
        fallosText.text = fallos.ToString();
    }

}
