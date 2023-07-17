using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class iskelet : MonoBehaviour
{
    [SerializeField]
    Transform[] pozisyonlar;

    [SerializeField]
    float iskeletHizi = 4f;

    [SerializeField]
    float beklemesuresi=1f;
    
    float beklemeSayaci;
    Rigidbody2D rb;
    Animator ani;
    int kaciniciPoz;
    Transform playerHedef;
    bool sinirdami;


    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        ani=GetComponent<Animator>();
        sinirdami=false;

    }

    private void Start()
    {
        beklemeSayaci=beklemesuresi;
        playerHedef = GameObject.Find("Player").transform; // player i bul ve hedefi onun transformuna eþitle
        foreach (Transform poz in pozisyonlar)
        {
            poz.parent = null;
        }
    }
    private void Update()
    {
        if (playerHedef.GetComponent<OyuncuHareketleri>().OyuncuOlumu ||  GetComponent<iskeletSaglik>().iskeletOldumu)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            ani.SetBool("AtakYapti", false);
            ani.SetFloat("HareketHizi", 0f);
            return;
        }


        float mesafe = Vector2.Distance(playerHedef.position, transform.position); //iyi mesafe arasýný hesaplatýyoruz
        if (mesafe > 4) 
        { 
            sinirdami = false;
        }
        else
        {
            sinirdami= true;
        }

        if (!sinirdami)
        {
            if (Mathf.Abs(transform.position.x - pozisyonlar[kaciniciPoz].position.x)>0.2f)
            {
                if (transform.position.x < pozisyonlar[kaciniciPoz].position.x)//karakterimizin poz. g.deceði poz. dan küçük ise
                {
                    rb.velocity = new Vector2(iskeletHizi, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(-iskeletHizi, rb.velocity.y);
                }
            transform.localScale= new Vector2(Mathf.Sign(rb.velocity.x), 1f);
            } else
            {
                rb.velocity=new Vector2(0,rb.velocity.y);
                beklemeSayaci -= Time.deltaTime;
                if (beklemeSayaci<=0)
                {
                    beklemeSayaci = beklemesuresi;
                    kaciniciPoz ++;

                    if (kaciniciPoz >= pozisyonlar.Length)
                        kaciniciPoz = 0;
                    
                }
            }
        }
        else
        {
            Vector2 yonvectoru = transform.position - playerHedef.position;
            if (yonvectoru.magnitude>1.5f && playerHedef!=null)
            {
                if (yonvectoru.x>0)
                {
                    rb.velocity = new Vector2(-iskeletHizi, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(iskeletHizi, rb.velocity.y);
                }
                ani.SetBool("AtakYapti", false);
                transform.localScale=new Vector2(Mathf.Sign(rb.velocity.x) , 1f);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                ani.SetBool("AtakYapti",true);
            }







        }


        ani.SetFloat("HareketHizi",math.abs(rb.velocity.x));



    }


}
