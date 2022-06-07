using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceScript : MonoBehaviour
{

    public AudioSource music;
    public GameObject uiObject;

    private void Start()
    {
        uiObject.SetActive(false);
    }
    private void Update()
    {
        if (music.isPlaying)
        {
            uiObject.SetActive(true);
        }
        else
        {
            uiObject.SetActive(false);
        }
    }

}