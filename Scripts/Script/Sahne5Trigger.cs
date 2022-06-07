using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sahne5Trigger : MonoBehaviour
{
    [SerializeField] AudioClip ses1, ses3;
    [SerializeField] GameObject lastLine;
    [SerializeField] GameObject sesSimgesi;
    [SerializeField] GameObject gorev1;
    [SerializeField] GameObject cip1Gorev;
    [SerializeField] GameObject cip2Gorev;
    [SerializeField] GameObject gorev3;
    [SerializeField] GameObject gorev1Tik;
    [SerializeField] GameObject cip1Tik;
    [SerializeField] GameObject cip2Tik;
    public int cipSayi = 0;
    

    private void Start()
    {
        StartCoroutine(Voice());

    }

    private void Update()
    {
        if (cipSayi == 1)
        {
            cip1Tik.SetActive(true);
        }
        else if (cipSayi == 2)
        {
            cip2Tik.SetActive(true);
            gorev3.SetActive(true);
        }
        SesSimgesi();
    }
    void SesSimgesi()
    {
        if (GetComponent<AudioSource>().isPlaying || lastLine.GetComponent<AudioSource>().isPlaying)
        {
            sesSimgesi.SetActive(true);
        }
        else if (!GetComponent<AudioSource>().isPlaying && !lastLine.GetComponent<AudioSource>().isPlaying)
        {
            sesSimgesi.SetActive(false);
        }
    }

    IEnumerator Voice()
    {
        yield return new WaitForSeconds(1);
        GetComponent<AudioSource>().PlayOneShot(ses1);
        yield return new WaitForSeconds(16.5f);
        gorev1.SetActive(true); 

}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            GetComponent<AudioSource>().PlayOneShot(ses3);
            cip1Gorev.SetActive(true);
            cip2Gorev.SetActive(true);
            gorev1Tik.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
