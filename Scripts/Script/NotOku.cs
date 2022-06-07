using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotOku : MonoBehaviour
{
    [SerializeField] AudioClip tabletGiris;
    [SerializeField] AudioClip tabletCikis;
    [SerializeField] GameObject playerObjesi;
    [SerializeField] TextMeshProUGUI pressText;
    [SerializeField] Image notTableti1;
    bool okunabilir = false;
    bool dokunuyor = false;
    
    private void Update()
    {


        NotTableti1();
        if (dokunuyor)
        {
            pressText.gameObject.SetActive(true);
        }
        else
        {
            pressText.gameObject.SetActive(false);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            dokunuyor = true;
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            dokunuyor = false;
            okunabilir = false;
        }


    }

    void NotTableti1()
    {
        if (dokunuyor)
        {
            if (Input.GetKeyDown(KeyCode.E) && !okunabilir)
            {
                okunabilir = true;
                GetComponent<AudioSource>().PlayOneShot(tabletGiris);
                Debug.Log("Tablet1 aktif");
            }
            else if (Input.GetKeyDown(KeyCode.E) && okunabilir)
            {
                okunabilir = false;
                GetComponent<AudioSource>().PlayOneShot(tabletCikis);
                Debug.Log("Tablet1 pasif");
            }
        }

        if (okunabilir)
        {
            
            notTableti1.gameObject.SetActive(true);
        }
        else if (!okunabilir)
        {
            notTableti1.gameObject.SetActive(false);
        }


    }







}
