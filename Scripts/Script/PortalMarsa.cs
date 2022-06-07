using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalMarsa : MonoBehaviour
{
    [SerializeField] AudioClip portalSesi;
    [SerializeField] int gidilecekSahne;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            StartCoroutine(SahneGecis());
        }
    }

    IEnumerator SahneGecis()
    {
        GetComponent<AudioSource>().PlayOneShot(portalSesi);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(gidilecekSahne);
    }
}
