using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject cikis;
    public GameObject sahnebelirtici1;
    public GameObject sahnebelirtici2;
    public GameObject sahnebelirtici3;
    public GameObject sahnebelirtici4;
    public GameObject sahnebelirtici5;

    public int TopAltýn;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        TopAltýn = 0;
    }
    private void Update()
    {
        if (sahnebelirtici1.activeInHierarchy)
        { if (TopAltýn == 8) { cikis.SetActive(false); } }

        if (sahnebelirtici2.activeInHierarchy)

        { if (TopAltýn == 7) { cikis.SetActive(false); } }

        if (sahnebelirtici3.activeInHierarchy)
        { if (TopAltýn == 6) { cikis.SetActive(false); } }


        if (sahnebelirtici4.activeInHierarchy)
        { if (TopAltýn == 3) { cikis.SetActive(false); } }


        if (sahnebelirtici5.activeInHierarchy)
        { if (TopAltýn == 6) { cikis.SetActive(false); } }








        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.instance.PausePanelAC();
        }
    }

    public void OyunCikisEkraniAc()
    {
        UIManager.instance.BitisPanelAC();
    }

}
        