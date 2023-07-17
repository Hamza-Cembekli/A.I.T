using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeController : MonoBehaviour
{

    public static FadeController instance;   


    [SerializeField]
    GameObject FadeIMG;
   

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        MattanSeffafa();
    }

    public void SeffaftanMata()
    {
        FadeIMG.GetComponent<CanvasGroup>().alpha = 0f;
        FadeIMG.GetComponent<CanvasGroup>().DOFade(1f,1f);//yumusak geçiþi saðlýyor son deðer ve süre ister
          
    }

    public void MattanSeffafa()
    {
        
            FadeIMG.GetComponent<CanvasGroup>().alpha = 1f;
            FadeIMG.GetComponent<CanvasGroup>().DOFade(0f, 3f);
   
    }
}
