using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceTrigger : MonoBehaviour
{
    public int missionCompleteSound;
    [SerializeField] AudioClip missionSound1;
    [SerializeField] AudioClip missionSound2;
    [SerializeField] AudioClip missionSound3;
    [SerializeField] GameObject sleepTrigger;
    [SerializeField] GameObject missionText;
    [SerializeField] GameObject portal;
    [SerializeField] AudioSource ses;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            ses.Play();
            Destroy(GetComponent<BoxCollider>());
            if (missionCompleteSound == 2)
            {
                if(!GetComponent<AudioSource>().isPlaying)
                {
                Destroy(gameObject);
                }
            }
            if (missionCompleteSound == 1)
            {
                StartCoroutine(Voice());
                missionText.SetActive(true);
                portal.SetActive(true);
            }
        }
    }

    IEnumerator Voice()
    {
                GetComponent<AudioSource>().PlayOneShot(missionSound1,.7f);
        yield return new WaitForSeconds(5);
        GetComponent<AudioSource>().PlayOneShot(missionSound2, .7f);
        yield return new WaitForSeconds(8);
        GetComponent<AudioSource>().PlayOneShot(missionSound3, .7f);
        sleepTrigger.SetActive(true);
    }
}
