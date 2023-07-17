using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iskeletSaglik : MonoBehaviour
{
    public int maxSaglik;
    int gecerlisaglik;
    public bool iskeletOldumu;

    private void Start()
    {
        gecerlisaglik=maxSaglik;
        iskeletOldumu = false;

    }
    public void CanAzalt()
    {
        gecerlisaglik --;
        if (gecerlisaglik <=0)
        {
            gecerlisaglik= 0;
            iskeletOldumu= true;
            GetComponent<Animator>().SetTrigger("CanVerdi");
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, 1f);
        }
       
        
    
    }
}
