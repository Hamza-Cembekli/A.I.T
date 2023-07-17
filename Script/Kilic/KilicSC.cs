using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilicSC : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<OyuncuHareketleri>().KiliciAC();



            Destroy(gameObject);
        }
    }
}
