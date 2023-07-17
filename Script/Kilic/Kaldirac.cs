using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Kaldirac : MonoBehaviour
{
    [SerializeField]
    GameObject AcýlacakNesne;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KilicVurusKutusu"))
        {
            GetComponent<Animator>().SetTrigger("KaldiracA");
            GetComponent<BoxCollider2D>().enabled= false;
            AcýlacakNesne.transform.DOLocalMoveY(AcýlacakNesne.transform.localPosition.y+0.4f, 1f);

        }
    }
}
