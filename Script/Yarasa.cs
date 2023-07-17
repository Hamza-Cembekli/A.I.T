using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yarasa : MonoBehaviour
{
    [SerializeField]
    Transform[] pozisyonlar;



    public float YarasaHiz;
    public float BeklemeSüresi;
    float beklemeSayac;
    int PozSay;
    Animator ani;
    Vector2 kusyonu;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        foreach (Transform pos in pozisyonlar)
        {
            pos.parent = null;
        }//pozisyon belirteçlerini yara nesnesinden çýkartmak için yapýyoruz
    }

    private void Start()
    {
        PozSay= 0;
        transform.position = pozisyonlar[PozSay].position;
    }

    private void Update()
    {
        if (beklemeSayac>0)
        {
            beklemeSayac -= Time.deltaTime;
            ani.SetBool("Ucsunmu",false);
        }
        else
        {
            kusyonu = new Vector2(pozisyonlar[PozSay].position.x - transform.position.x, pozisyonlar[PozSay].position.y - transform.position.y);
            float angle = Mathf.Atan2(kusyonu.y, kusyonu.x)*Mathf.Rad2Deg;
            if (transform.position.x > pozisyonlar[PozSay].position.x)
            {
                transform.localScale = new Vector3(1, -1, 1);
            }
            else
            {
                transform.localScale = Vector3.one;
            }
            transform.rotation=Quaternion.Euler(0,0,angle);
            
            transform.position = Vector3.MoveTowards(transform.position, pozisyonlar[PozSay].position, YarasaHiz * Time.deltaTime);
            
            ani.SetBool("Ucsunmu", true);

            if (Vector3.Distance(transform.position, pozisyonlar[PozSay].position)<0.1f)
            {
                PozDegis();
                beklemeSayac = BeklemeSüresi;
            }
        }
    }

    void PozDegis ()
    {

        PozSay++;
        if (PozSay>=pozisyonlar.Length)
        {
            PozSay = 0;
        }
    }
}
