using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceTrigger2 : MonoBehaviour
{
    [SerializeField] AudioSource ses1;
    bool degdi = false;
    private void Update()
    {
        if (degdi)
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            ses1.Play();
            degdi = true;
        }
    }
}
