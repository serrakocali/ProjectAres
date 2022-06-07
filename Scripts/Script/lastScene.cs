using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastScene : MonoBehaviour
{
    [SerializeField] GameObject hedef;
    [SerializeField] GameObject screen;
    float sayi = .006f;
    bool zaman = false;

    private void Start()
    {
        Invoke("Sayi", 12f);
        Invoke("Baslangic", 3f);
        Invoke("Bitis", 16f);
        Invoke("Exit", 30f);
    }

    void Sayi()
    {
        sayi = 0.9f;
    }

    void Baslangic()
    {
        zaman = true;
    }
    private void Update()
    {
        if (zaman)
        {
        transform.position = Vector3.Lerp(transform.position, hedef.transform.position, sayi * Time.deltaTime);
        }
    }

    void Bitis()
    {
        screen.SetActive(true);
    }

    void Exit()
    {
        Application.Quit();
    }










}
