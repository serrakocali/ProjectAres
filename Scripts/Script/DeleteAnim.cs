using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAnim : MonoBehaviour
{
    private void Start()
    {
        ComponentiSil();
    }

    void ComponentiSil()
    {
        Destroy(gameObject, 4.99f);
    }

}
