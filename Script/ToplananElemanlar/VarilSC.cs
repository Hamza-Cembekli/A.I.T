using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarilSC : MonoBehaviour
{
    Animator Ani;
    int VurusSayisi;

    [SerializeField]
    GameObject ParlamaEffect;
    [SerializeField]
    GameObject CoinPref;

    Vector2 PatlamaMik = new Vector2(1,4);
    private void Awake()
    {
        Ani = GetComponent<Animator>();
        VurusSayisi = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KilicVurusKutusu"))
        {
            if (VurusSayisi<4)
            {
                Ani.SetTrigger("Sallanma");
                Instantiate(ParlamaEffect,transform.position,transform.rotation);
            }
            else
            {
                GetComponent<BoxCollider2D>().enabled= false;
                Ani.SetTrigger("Parcalanma");

                for (int i = 0; i < 5; i++)
                {
                    Vector3 rastgele = new Vector3(transform.position.x + (i - 1),transform.position.y,transform.position.z);
                    GameObject coin = Instantiate(CoinPref, rastgele, transform.rotation);
                    coin.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    coin.GetComponent<Rigidbody2D>().velocity = PatlamaMik * new Vector2(Random.Range(1,2),transform.localScale.y+Random.Range(0,2));
                }


            }
            VurusSayisi++;
        }
    }





}
