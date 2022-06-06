using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugTusu : MonoBehaviour
{
    public GameObject obj;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            transform.position = new Vector3(2082f, 228f, transform.position.z);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
