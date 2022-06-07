using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemiDon : MonoBehaviour
{
    [SerializeField] AudioSource ses1;
    [SerializeField] GameObject sesSimge;

    private void Start()
    {
        StartCoroutine(Voice());
    }
    private void Update()
    {
        if (GetComponent<AudioSource>().isPlaying)
        {
            sesSimge.SetActive(true);
        }
        else if (!GetComponent<AudioSource>().isPlaying)
        {
            sesSimge.SetActive(false);
        }


       

    }
 IEnumerator Voice()
        {
            yield return new WaitForSeconds(2);
            ses1.Play();
        }
}
