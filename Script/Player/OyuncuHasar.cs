using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuHasar : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D KilicVurus;
    [SerializeField]
    GameObject ParlamaEfekti;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (KilicVurus.IsTouchingLayers(LayerMask.GetMask("dusmanLayer")))
        {
            if (collision.CompareTag("orumcek"))
            {
                if (ParlamaEfekti)
                {
                    Instantiate(ParlamaEfekti, collision.transform.position, Quaternion.identity);
                }
              
                StartCoroutine(collision.GetComponent<Orumcek>().geriTepki());

               

            }
        }

        if (KilicVurus.IsTouchingLayers(LayerMask.GetMask("iskelet")))
        {
            if (collision.CompareTag("iskelet"))
            {
                if (ParlamaEfekti)
                {
                    Instantiate(ParlamaEfekti, collision.transform.position, Quaternion.identity);
                }
                collision.GetComponent<iskeletSaglik>().CanAzalt();
            }
        }
    }
}
