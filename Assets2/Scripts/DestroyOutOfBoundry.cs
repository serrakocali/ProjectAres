using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundry : MonoBehaviour
{
    public Transform cubeEnemy;
    public Transform t2;
    private void Update()
    {
        if (Vector3.Distance(cubeEnemy.position, t2.position) >= 1600)

        {
            Destroy(cubeEnemy.gameObject);
        }
    }

}
