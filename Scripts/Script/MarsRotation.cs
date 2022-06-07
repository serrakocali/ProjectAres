using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarsRotation : MonoBehaviour
{
    public float rotationSpeed = 7.0f;

    private void Start()
    {
        StartCoroutine(DigerSahne());
    }


    void Update()
    {
        transform.Rotate(new Vector3(0f, rotationSpeed, 0f) * Time.deltaTime);
    }

    IEnumerator DigerSahne()
    {
        yield return new WaitForSeconds(30);
        SceneManager.LoadScene(2);
    }




}
