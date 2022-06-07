using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reactorUIscript : MonoBehaviour
{
    [SerializeField] GameObject reactorGorev;
    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnDestroy()
    {
        reactorGorev.SetActive(true);
    }
}
