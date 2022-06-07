using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    [SerializeField] AudioSource ses1;
    [SerializeField] AudioSource ses2;
    [SerializeField] AudioSource ses3;

    public void Fonksiyonn()
    {
        StartCoroutine(NewGame());
    }
   public  IEnumerator NewGame()
    {
        ses1.Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);

    }
    public void GirisSesi()
    {
        ses2.Play();
    }

    public void CikisSesi()
    {
        ses3.Play();
    }


     
}
