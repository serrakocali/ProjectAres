using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VelocityMeter : MonoBehaviour
{
    public  TextMeshProUGUI text2;
        public float speed;
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
            speed = Mathf.RoundToInt(Vector3.Distance(transform.position, prevPos) / Time.fixedDeltaTime);

        }

    }
    private void Update()
    {
        if(speed < 450)
        text2.text = speed + "  KM / H";

        if (speed >= 800)
        {
            text2.text = speed + "  KM / H      !!!!!!!GODMODE!!!!!!!!";
        }
        if (speed >= 500 && speed < 800)
        {
            text2.text = speed + "  KM / H      ROKET HIZINA ULASTIN";
        }

        
    }
}
