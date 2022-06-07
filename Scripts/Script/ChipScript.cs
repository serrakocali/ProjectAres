using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipScript : MonoBehaviour
{
    [SerializeField] AudioClip collect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Destroy(gameObject);
        }
    }

}
