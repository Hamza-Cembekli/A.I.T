using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
  public static UIManager instance;

    [SerializeField]
    Slider PlayerSlider;
    [SerializeField]
    TMP_Text CoinText;
    [SerializeField]
    GameObject PausePanel;
    [SerializeField]
    GameObject BitisPanel;
    public string digerSahne;



    private void Awake()
    {
        instance= this;
    }

    public void SliderGuncelle(int gecerliDeger,int maxDeger)
    {
        PlayerSlider.maxValue= maxDeger;
        PlayerSlider.value= gecerliDeger;
    }

    public void ParaTopla()
    {
        CoinText.text=GameManager.instance.TopAltýn.ToString();
    }

    public void PausePanelAC() {


        if (!PausePanel.activeInHierarchy)
        {
            PausePanel.SetActive(true);
            Time.timeScale= 0f;//zamaný durdurma
        }
        else
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    
    }
    public void AnaMenu()
    {

        SceneManager.LoadScene("AnaMenu");
    }
    public void BitisPanelAC()
    {
        BitisPanel.SetActive(true);

    }
    public void tekrarOyna()
    {
        FadeController.instance.SeffaftanMata();
        StartCoroutine(SahneyeGec());

    }
    IEnumerator SahneyeGec() { yield return new WaitForSeconds(1f); SceneManager.LoadScene(digerSahne); }
    public void Cikis()
    {
        Application.Quit();
    }
}
