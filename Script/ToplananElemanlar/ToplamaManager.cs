using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplamaManager : MonoBehaviour
{
    [SerializeField]
    bool coinmi;


    bool toplandimi;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& !toplandimi)
        {
            toplandimi = true;

            GameManager.instance.TopAltýn++;
            UIManager.instance.ParaTopla();
            Destroy(gameObject);
           
        }
    }

}
