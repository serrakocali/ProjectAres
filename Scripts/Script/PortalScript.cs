using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    [SerializeField] int gidilecekSahne;
    [SerializeField] GameObject GozleriKapat;
    [SerializeField] GameObject gorevBildirimKapat;
    [SerializeField] AudioClip PortalSesi;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            UykuZamani();
            StartCoroutine(SahneGecis());
        }
    }

    void UykuZamani()
    {
        GozleriKapat.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(PortalSesi);
        gorevBildirimKapat.GetComponent<Text>().enabled = false;
    }



    IEnumerator SahneGecis()
    {
        
        
            yield return new WaitForSeconds(4);
            SceneManager.LoadScene(gidilecekSahne);
        
        



    }








}
