using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reaktorGorev1 : MonoBehaviour
{
    [SerializeField] GameObject gorev1;
    [SerializeField] GameObject cube;
    [SerializeField] GameObject etkilesimYazi;
    [SerializeField] GameObject light1;
    [SerializeField] GameObject light2;
    [SerializeField] GameObject light3;
    [SerializeField] int sayi;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player") && sayi != 1)
        {
            gorev1.SetActive(true);
            Destroy(gameObject,1f);
            
        }

        if (other.CompareTag("player") && sayi == 1)
        {
            etkilesimYazi.SetActive(true);
                if ( Input.GetKeyDown(KeyCode.E))
            {
                gorev1.SetActive(true);
                cube.GetComponent<Animator>().enabled = true;
                Debug.Log("e'ye basýldý");

            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player") && sayi == 1)
        { 
            if (Input.GetKeyDown(KeyCode.E))
            {
                gorev1.SetActive(true);
                cube.GetComponent<Animator>().enabled = true;
               GetComponent<AudioSource>().enabled = false;
                light1.SetActive(true);
                light2.SetActive(true);
                light3.SetActive(true);
                StartCoroutine(NextScene());

       
                Debug.Log("e'ye basýldý");
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
       

        if (other.CompareTag("player") && sayi == 1)
        {
            etkilesimYazi.SetActive(false);

        }
    }

    private void OnDestroy()
    {
        etkilesimYazi.SetActive(false);
    }

    
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(7);
    }




}
