using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] float shipSpeed;
    private void Update()
    {
        transform.Translate(new Vector3(0f, 0f, shipSpeed) * Time.deltaTime);

    }
}
