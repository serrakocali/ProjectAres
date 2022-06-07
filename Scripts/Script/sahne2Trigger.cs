using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sahne2Trigger : MonoBehaviour
{
    [SerializeField] AudioClip ses1, ses2;
    [SerializeField] GameObject sesSimgesi;
    [SerializeField] GameObject eyeClose1;
    [SerializeField] GameObject eyeClose2;

    private void Start()
    {
        StartCoroutine(VoiceTime());
    }
    private void Update()
    {
        SesSimgesi();

        
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
        }
    }


    IEnumerator VoiceTime()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<AudioSource>().PlayOneShot(ses1);
        yield return new WaitForSeconds(6.7f);
        GetComponent<AudioSource>().PlayOneShot(ses2);
        yield return new WaitForSeconds(98f);
        eyeClose1.SetActive(true);
        eyeClose2.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(3);
    }


}
