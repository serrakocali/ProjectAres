using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GezegenScript : MonoBehaviour
{
    [SerializeField] float dondurmeHizi;
    void Update()
    {
        transform.Rotate(new Vector3(0f, dondurmeHizi, 0f) * Time.deltaTime);
    }
    
}
