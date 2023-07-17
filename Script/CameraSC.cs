using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraSC : MonoBehaviour
{
    OyuncuHareketleri oyuncuKontrolu;
    [SerializeField]
    Collider2D boundsbox;

    float yukseklik, genislik;


    Vector2 sonPos;
    [SerializeField]
    Transform backgrounds;

    private void Awake()
    {
        oyuncuKontrolu = Object.FindObjectOfType<OyuncuHareketleri>();
    }
    private void Start()
    {
        yukseklik = Camera.main.orthographicSize;
        genislik = yukseklik * Camera.main.aspect;
        sonPos = transform.position;
    }
    private void Update()
    {
        if (oyuncuKontrolu != null)
        {
            transform.position = new Vector3(
               Mathf.Clamp(oyuncuKontrolu.transform.position.x,boundsbox.bounds.min.x+genislik,boundsbox.bounds.max.x-genislik),
               Mathf.Clamp(oyuncuKontrolu.transform.position.y,boundsbox.bounds.min.y+yukseklik,boundsbox.bounds.max.y-genislik),
                transform.position.z);
        }
        if (backgrounds != null)
        {
            backgroundsHareket();
        }
      
    }
    void backgroundsHareket()
    {
        Vector2 arasindakiFark = new Vector2(transform.position.x - sonPos.x, transform.position.y - sonPos.y);
        backgrounds.position += new Vector3(arasindakiFark.x, arasindakiFark.y, 0f);
        sonPos=transform.position;
    }

    
}
