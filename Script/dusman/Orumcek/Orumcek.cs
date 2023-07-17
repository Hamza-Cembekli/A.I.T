using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orumcek : MonoBehaviour
{
    [SerializeField]
    Transform[] Pozisyonlar;

    [SerializeField]
    Slider OrumcekSlider;
    
    public float orumcekHizi;
    public float beklemeSuresi;
    public float TakipMesafesi=5f;
    public int maxSaglik;
    int gecerliSaglik;
    float beklemeSayac;
    int kacinciPoz;
    bool AtakYapabilirmi;
    
    Animator ani;
    Transform HedefPlayer;
    BoxCollider2D orumcekColider;
    Rigidbody2D rb;

    private void Start()
    {
        gecerliSaglik = maxSaglik;
        SliderGuncelle();
        HedefPlayer = GameObject.Find("Player").transform;
        foreach (Transform poz in Pozisyonlar)
        {
            poz.parent = null;
        }
    }

    private void Awake()
    {
        OrumcekSlider.maxValue = maxSaglik;
        ani= GetComponent<Animator>();
        orumcekColider=GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        AtakYapabilirmi = true;
    }

    private void Update()
    {
        if (!AtakYapabilirmi)
        {
            return;
        }
        if (beklemeSayac>0)
        {
            beklemeSayac -= Time.deltaTime;
            ani.SetBool("Hareket", false);


        }
        else
        {
            if (HedefPlayer.position.x > Pozisyonlar[0].position.x && HedefPlayer.position.x < Pozisyonlar[1].position.x)
            {

                Vector3 YeniPos = HedefPlayer.position;
                YeniPos.y = transform.position.y;


                transform.position = Vector3.MoveTowards(transform.position, YeniPos, orumcekHizi * Time.deltaTime);
                ani.SetBool("Hareket", true);
                

                if (transform.position.x > HedefPlayer.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (transform.position.x < HedefPlayer.position.x)
                {
                    transform.localScale = Vector3.one;
                }
            }
            else
            {
                ani.SetBool("Hareket", true);

                if (transform.position.x > Pozisyonlar[kacinciPoz].position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (transform.position.x < Pozisyonlar[kacinciPoz].position.x)
                {
                    transform.localScale = Vector3.one;
                }


                transform.position = Vector3.MoveTowards(transform.position, Pozisyonlar[kacinciPoz].position, orumcekHizi * Time.deltaTime);//towards  sürükleme metodu. geçerli ve  hedef vektör vede süresi
                if (Vector3.Distance(transform.position, Pozisyonlar[kacinciPoz].position) < 0.1f)
                {
                    beklemeSayac = beklemeSuresi;
                    pozDegis();
                }

            }





            
        }
    }

    void pozDegis()
    {
        kacinciPoz++;
        if (kacinciPoz>= Pozisyonlar.Length)
        {
            kacinciPoz = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(1, (float)0.5, 1));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (orumcekColider.IsTouchingLayers(LayerMask.GetMask("playerLayer"))&& AtakYapabilirmi)
        {
            AtakYapabilirmi = false;
            ani.SetTrigger("Atak");
            collision.GetComponent<SaglikKontrol>().CanAzalt();
            StartCoroutine(yeniAtak());
        }
    }

    IEnumerator yeniAtak()
    {
        yield return new WaitForSeconds(1f);
   

        if (gecerliSaglik>0)
        {
            AtakYapabilirmi = true;
        }

    }

    public IEnumerator geriTepki()
    {
        AtakYapabilirmi = false;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(.1f);
        gecerliSaglik--;
        SliderGuncelle();
        if (gecerliSaglik<=0)
        {
            AtakYapabilirmi=false;
            gecerliSaglik = 0;
            ani.SetTrigger("Olu");
            orumcekColider.enabled = false;
            Destroy(gameObject, 1f);
            OrumcekSlider.gameObject.SetActive(false);
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                rb.velocity = new Vector2(-transform.localScale.x + 1, rb.velocity.y);
                yield return new WaitForSeconds(0.1f);

            }

            
            ani.SetBool("Hareket", false);
           yield return new WaitForSeconds(0.25f);
            rb.velocity = Vector2.zero;
            AtakYapabilirmi=true;
        }
    }




    void SliderGuncelle()
    {
        OrumcekSlider.value = gecerliSaglik;
    }



}
