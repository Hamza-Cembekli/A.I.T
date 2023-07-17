using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.SceneManagement;

public class OyuncuHareketleri : MonoBehaviour
{
    public static OyuncuHareketleri instance;

    Rigidbody2D rb;

    [SerializeField]
    GameObject normalPlayer, kilicPlayer;

    [SerializeField]
    Transform ZeminKontrol;

    [SerializeField]
    Animator NormalAni,KilicAni;

    [SerializeField]
    float GeriTepkiSuresi, GeriTepkiGucu;

    [SerializeField]
    SpriteRenderer NormalSr,KilicSr;

    [SerializeField]
    GameObject KilicVurusOBJ;

 


    float geriTepkiSayaci;
    public LayerMask ZeminMaske;
    public float HareketHizi;
    public float ZiplamaGucu;
    bool zemindemi;
    bool ikinickezziplama;
    bool sagdami;
   public bool OyuncuOlumu;
    bool KiliciVurdumu;
    public GameObject kilicvur;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();//scripti verdiðimiz nesnenin rb sine eriþiyoruz
        instance = this;
        OyuncuOlumu = false;
        KiliciVurdumu=false;
        KilicVurusOBJ.SetActive(false);
    }

    private void Update()
    {
        if (OyuncuOlumu)
        {
            return;
        }

        if (geriTepkiSayaci<=0)
        {
            Hareket();
            Zipla();
            YonuDegis();

            if (normalPlayer.activeSelf)
            {
                NormalSr.color = new Color(NormalSr.color.r, NormalSr.color.g, NormalSr.color.b, 1f);
            }
            if (kilicPlayer.activeSelf)
            {
                KilicSr.color = new Color(KilicSr.color.r, KilicSr.color.g, KilicSr.color.b, 1f);
            }

            if (kilicvur.activeInHierarchy && kilicPlayer.activeSelf)
            {
                KiliciVurdumu = true;
                KilicVurusOBJ.SetActive(true);
            }
            else
            {
                KiliciVurdumu = false;
            }

        }
        else
        {
            geriTepkiSayaci -= Time.deltaTime;
            if (sagdami)
            {
                rb.velocity = new Vector2(-GeriTepkiGucu, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(GeriTepkiGucu, rb.velocity.y);
            }
        }

        

        if (normalPlayer.activeSelf)
        {
            NormalAni.SetBool("zemindemi", zemindemi);//zeminde olup olmadýðýný kontrol ediyoruz
            NormalAni.SetFloat("HareketHizi", math.abs(rb.velocity.x));//math.abs= mutlak deðer alýyor 
        }
        if (kilicPlayer.activeSelf)
        {
            KilicAni.SetBool("zemindemi", zemindemi);//zeminde olup olmadýðýný kontrol ediyoruz
            KilicAni.SetFloat("HareketHizi", math.abs(rb.velocity.x));//math.abs= mutlak deðer alýyor 
            
        }

        if (KiliciVurdumu && kilicPlayer.activeSelf)
        {
            KilicAni.SetTrigger("Atak");
        }





    }

    void Hareket()
    {

        float h = Input.GetAxis("Horizontal");// klavyenin tuþuna basýldýðýnda + - 1 arasýnda deðer çevirir
        rb.velocity = new Vector2(h * HareketHizi, rb.velocity.y);

    }

    void YonuDegis()
    {
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            sagdami = false;
         
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            sagdami=true;
           
        }
    }

    private void Zipla()
    {
        zemindemi = Physics2D.OverlapCircle(ZeminKontrol.position, .2f, ZeminMaske);
        if (Input.GetButtonDown("Jump") && (zemindemi || ikinickezziplama))
        {
            if (zemindemi)
            {
                ikinickezziplama = true;
            }
            else
            {
                ikinickezziplama = false;
            }
            rb.velocity = new Vector2(rb.velocity.x, ZiplamaGucu);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "elevator_gear")
        {
            Destroy(collision.gameObject);
            Debug.Log("aldým");

        }
    }

    public void GeriTepki()
    {
        geriTepkiSayaci = GeriTepkiSuresi;

        if (normalPlayer.activeSelf)
        {
            NormalSr.color = new Color(NormalSr.color.r, NormalSr.color.g, NormalSr.color.b, 0.5f);
        }
        if (kilicPlayer.activeSelf)
        {
            KilicSr.color = new Color(KilicSr.color.r, KilicSr.color.g, KilicSr.color.b, 0.5f);
        }




        

        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    public void CanVerme()
    {
        rb.velocity=Vector2.zero;
        OyuncuOlumu = true;

        if (normalPlayer.activeSelf)
        {
            NormalAni.SetTrigger("CanVerdi");
        }
        if (kilicPlayer.activeSelf)
        {
            KilicAni.SetTrigger("CanVerdi");
        }
  
        StartCoroutine(Sahneyenile());
    }

    IEnumerator Sahneyenile()
    {
        yield return new WaitForSeconds(2f);
        GetComponentInChildren<SpriteRenderer>().enabled=false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Aktif Olan sahnenin index numarasýný alýp atýyor ayný kod satýrýna
        
    }

    public void KiliciAC()
    {
        //Normal çarý kapatýp kýlýçlý çarý aktif ediyoruz
      
        normalPlayer.SetActive(false);
        kilicPlayer.SetActive(true);

    }
    public void NormaliAC()
    {
        //Normal çarý kapatýp kýlýçlý çarý aktif ediyoruz
   
        normalPlayer.SetActive(true);
        kilicPlayer.SetActive(false);

    }

    public void HareketYok()
    {
        if (normalPlayer.activeSelf)
        {
            rb.velocity = Vector2.zero;
            NormalAni.SetFloat("HareketHizi", 0f);
        }
        if (kilicPlayer.activeSelf)
        {
            rb.velocity = Vector2.zero;
            KilicAni.SetFloat("HareketHizi", 0f);
        }
       
    }
 

}