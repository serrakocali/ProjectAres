using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            transform.position += new Vector3(0, 0, transform.GetComponent<Renderer>().bounds.size.z * 5);
        }
    }
}
