using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbejaManager : MonoBehaviour
{
    public static AbejaManager Instance;
    public GameObject Prefab;
    public GameObject Parent;
    public int duration=10;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        InvokeRepeating(nameof(Spawner), 1.5f, 4f);
    }

    public void Spawner()
    {
        GameObject Abeja = Instantiate(Prefab, Parent.transform);
    }

}
