using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]  AudioClip line1;
    [SerializeField] GameObject altYazi1;
    [SerializeField] AudioClip line2;
    [SerializeField] GameObject altYazi2;
    [SerializeField] GameObject target;
    [SerializeField] GameObject target2;
    [SerializeField] GameObject target3;

    [SerializeField] GameObject playerCapsule;
    [SerializeField] GameObject infoMovement;
    [SerializeField] GameObject sesSimgesi;
    [SerializeField] float time1;
    [SerializeField] float time2;

    private void Start()
    {
      
        StartCoroutine(AiSes());
    }

    private void Update()
    {  
        SesSimgesi();
        
    }



    IEnumerator AiSes()
    {
        yield return new WaitForSeconds(time1);
        GetComponent<AudioSource>().PlayOneShot(line1);
        altYazi1.SetActive(true);

        yield return new WaitForSeconds(time2);

        playerCapsule.SetActive(true);
        infoMovement.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(line2);
        altYazi1.SetActive(false);
        altYazi2.SetActive(true);
        yield return new WaitForSeconds(4);
        altYazi2.SetActive(false);

        //altYazi1.SetActive(false);
        // altYazi2.SetActive(true);

    }

    void SesSimgesi()
    {
        if (GetComponent<AudioSource>().isPlaying || target.GetComponent<AudioSource>().isPlaying || target2.GetComponent<AudioSource>().isPlaying || target3.GetComponent<AudioSource>().isPlaying)
        {
            sesSimgesi.SetActive(true);
        }

        else if (!GetComponent<AudioSource>().isPlaying && !target.GetComponent<AudioSource>().isPlaying && !target2.GetComponent<AudioSource>().isPlaying && !target3.GetComponent<AudioSource>().isPlaying)
        {
            sesSimgesi.SetActive(false);
        }
    }




}
