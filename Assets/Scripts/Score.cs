using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI text3;
    public GameObject obj;
    public float distanceScore;
     void Start()
    {
        StartCoroutine(mesafeMeter());
    }
    IEnumerator mesafeMeter()
    {
        bool mesafe = true;
        while (mesafe)
        {
            yield return new WaitForFixedUpdate();
            distanceScore = Mathf.RoundToInt(Vector3.Distance(transform.position, obj.transform.position)/ 3);
        }
    }
    private void Update()
    {
        
            text3.text = distanceScore + "";
        
    }
}
