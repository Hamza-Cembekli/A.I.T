using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenuController : MonoBehaviour
{
    public string digerSahne;
   public void OyunaBasla()
    {
 
        StartCoroutine(SahneyeGec());


    }
    IEnumerator SahneyeGec() { yield return new WaitForSeconds(1f); SceneManager.LoadScene(digerSahne); }
    public void OyundanCýk()
    {
        Application.Quit();
    }
}
