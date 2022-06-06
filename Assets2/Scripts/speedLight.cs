using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedLight : MonoBehaviour
{
    private float speedL;
    // Light lightOn;
    //  public GameObject lightSwitch;
    void Start()
    {
        StartCoroutine(CalcSpeed());

    }
    IEnumerator CalcSpeed()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            Vector3 prevPos = transform.position;
            yield return new WaitForFixedUpdate();
            speedL = Mathf.RoundToInt(Vector3.Distance(transform.position, prevPos) / Time.fixedDeltaTime);

        }

    }
    void Update()
    {
        if (speedL >= 1200 ) 
        {
            this.GetComponent<Light>().intensity = 90;
            this.GetComponent<Light>().range = 150; 
        }

        if (speedL >= 900 && speedL < 1200)
        {
            this.GetComponent<Light>().intensity = 60;
            this.GetComponent<Light>().range = 120;
        }
        if (speedL >= 600 &&  speedL < 900)
        {
            this.GetComponent<Light>().intensity = 33;
            this.GetComponent<Light>().range = 100;
        }
        if ((speedL >= 250) && (speedL < 600))
           {
            this.GetComponent<Light>().intensity = 17;
            this.GetComponent<Light>().range = 50;
        }
    }
}
