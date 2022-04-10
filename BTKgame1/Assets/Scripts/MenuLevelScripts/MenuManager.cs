using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField]
    GameObject baslaButonu, cikisButonu;



    void Start()
    {
        FadeOut();
    }

    void FadeOut()
    {
        baslaButonu.GetComponent<CanvasGroup>().DOFade(1, 0.8f);
        cikisButonu.GetComponent<CanvasGroup>().DOFade(1, 0.8f).SetDelay(0.5f);
    }

    public void oyundanCik()
    {
        Application.Quit();
    }

    public void oyunaBasla()
    {
        SceneManager.LoadScene("GameLevel");
    }


   
}
