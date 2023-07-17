using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneCikisKontrol : MonoBehaviour
{
    public string DigerSahne;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<OyuncuHareketleri>().HareketYok();
            collision.GetComponent<OyuncuHareketleri>().enabled=false;
            FadeController.instance.SeffaftanMata();

        }
        StartCoroutine(DigerSahneyeGec());
    }
    IEnumerator DigerSahneyeGec()
    {
        yield return new WaitForSeconds(1f);//1 saniye bekledikten sonra
        SceneManager.LoadScene(DigerSahne);
    }

}
