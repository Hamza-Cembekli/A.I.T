using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Arduino : MonoBehaviour
{

    SerialPort seri = new SerialPort("COM3", 19200);
    public GameObject asansor;
    public float artisMiktari;
    public int iterasyonSayisi;
    public GameObject asansorcarki;
    public GameObject buz;
    public GameObject buz1;
    public GameObject clone;
    public GameObject player;
    public GameObject kilicvur;
    public GameObject karanlik;
   
    void Start()
    {
        seri.Open(); // seri portu dinliyor
        artisMiktari = 0.01f;
    }

   
    void Update()
    {
        int seriDeger = int.Parse(seri.ReadLine());//seri porttan gelen int veriyi seriDeger de�i�kenine at�yoruz
        Debug.Log(seriDeger);
        if (seriDeger == 100) //k�l�c�n vurdu�u mesaj�n� al�p oyunda bu i�lemi ge�ekle�tiriyor
        {
            kilicvur.SetActive(true);
        }
        else if(seriDeger == 99){ kilicvur.SetActive(false); Debug.Log(seriDeger); }
        if (seriDeger == 1624)
        {
            clone.SetActive(false);

            player.SetActive(true);
            buz.SetActive(false);
            buz1.SetActive(false);
        }


        if (seriDeger < 17)
        {
            iterasyonSayisi = seriDeger; // potansiyometreden gelen veriyi asans�r�n y�kseklik de�erine e�itliyor

            if (asansorcarki.activeInHierarchy)
            {
               
                Vector3 position = asansor.transform.position;
                position.y = seriDeger;
                asansor.transform.position = position;
            }
        }

        if (seriDeger == 155) { karanlik.SetActive(false); }
        if (seriDeger == 144) { karanlik.SetActive(true); }

    }
}

