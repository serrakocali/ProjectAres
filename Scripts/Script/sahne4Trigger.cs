using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sahne4Trigger : MonoBehaviour
{
    [SerializeField] GameObject sesSimgesi;
    [SerializeField] AudioClip ses1, ses2, ses3;
    [SerializeField] GameObject gorevText;
    private void Start()
    {
        StartCoroutine(Voice());
    }


    private void Update()
    {
        SesSimgesi();
    }



    IEnumerator Voice()
    {
        GetComponent<AudioSource>().PlayOneShot(ses1);
        yield return new WaitForSeconds(12);
        GetComponent<AudioSource>().PlayOneShot(ses2);
        yield return new WaitForSeconds(40);
        GetComponent<AudioSource>().PlayOneShot(ses3);
        gorevText.SetActive(true);
    }
    void SesSimgesi()
    {
        if (GetComponent<AudioSource>().isPlaying)
        {
            sesSimgesi.SetActive(true);
        }

        else if (!GetComponent<AudioSource>().isPlaying)
        {
            sesSimgesi.SetActive(false);
            GetComponent<BoxCollider>().enabled = false;
        }
    }


}
