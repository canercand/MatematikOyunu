using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class AlphaScript : MonoBehaviour
{

    public GameObject canerPanel;

    void Start()
    {
        canerPanel.GetComponent<CanvasGroup>().DOFade(0, 2f);
    }

    
}
