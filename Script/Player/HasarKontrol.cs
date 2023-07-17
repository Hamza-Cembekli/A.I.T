using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasarKontrol : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SaglikKontrol.instance.CanAzalt();
            OyuncuHareketleri.instance.GeriTepki();
        }
    }
}
