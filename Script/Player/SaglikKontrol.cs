using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaglikKontrol : MonoBehaviour
{
    public static SaglikKontrol instance;

    public int maxSaglik, gecerliSaglik;

    private void Awake()
    {
        instance= this;
    }
    private void Start()
    {
        gecerliSaglik = maxSaglik;
        if (UIManager.instance!= null)
        {
            UIManager.instance.SliderGuncelle(gecerliSaglik, maxSaglik);
        }
    
    }
    public void CanAzalt()
    {
        gecerliSaglik--;
        UIManager.instance.SliderGuncelle(gecerliSaglik, maxSaglik);
        if (gecerliSaglik<=0)
        {
            gecerliSaglik = 0;
            /*gameObject.SetActive(false);*///nesneyi kaybetme
            OyuncuHareketleri.instance.CanVerme();
        }
    }

    
}
