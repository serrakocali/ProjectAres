using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayEkraniText : MonoBehaviour
{
    [SerializeField] GameObject tarihText;

    private void Start()
    {
        Invoke("AktifEt", 2f);
    }


    void AktifEt()
    {
        tarihText.SetActive(true);
        Destroy(tarihText, 7f);
    }

    
}
