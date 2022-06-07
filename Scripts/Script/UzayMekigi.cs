using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayMekigi : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(new Vector3(0f, 0f, 20f) * Time.deltaTime);

    }
}
