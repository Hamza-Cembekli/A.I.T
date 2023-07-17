using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iskeletAtak : MonoBehaviour
{
    [SerializeField]
    Transform atakPos;

    [SerializeField]
    float atakYar;

    [SerializeField]
    LayerMask PlayerLayer;
    public void Atak()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(atakPos.position, atakYar,PlayerLayer);// atakpoz içindeki colliderlere bak ve playerlayeri bul
        if (playerCollider != null && !playerCollider.GetComponent<OyuncuHareketleri>().OyuncuOlumu) {

            playerCollider.GetComponent<SaglikKontrol>().CanAzalt();

        }
    }
    
    
    
    
    
    private void OnDrawGizmosSelected()//çerçeve belirleyen fonk
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(atakPos.position, atakYar);
    }
}
