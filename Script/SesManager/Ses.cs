using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ses : MonoBehaviour
{
    public static Ses instance;


    [SerializeField]
    AudioSource[] Sesler;
    private void Awake()
    {
      instance = this;
    }
    public void SesCikar(int hangiSes) 
    {
        Sesler[hangiSes].Stop();
        Sesler[hangiSes].Play();

    }
    public void farkliCikar(int hangiSes)
    {
        Sesler[hangiSes].Stop();
        Sesler[hangiSes].pitch= Random.Range(0.8f,1.3f);
        Sesler[hangiSes].Play();

    }


}
