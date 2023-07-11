using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InformationMenu : MonoBehaviour
{

    public GameObject player;

    public GameObject optionsMenu;



    //public TextMeshProUGUI totalCurrencyText;

    //public TextMeshProUGUI highScoreText;

    public void ActivateInfo()
    {
        if (gameObject.activeSelf)
        {
            DeactivateInfo();
            return;
        }
        
        
        optionsMenu.SetActive(false);
        gameObject.SetActive(true);
        if (player != null)
        {
            player.SetActive(false);
        }



        //totalCurrencyText.SetText("Total bananas colected: " + GameManager.Instance.totalCurrency.ToString());
        //highScoreText.SetText("Highest score: " + GameManager.Instance.maxPoints.ToString());

    }
    public void DeactivateInfo()
    {
        gameObject.SetActive(false);
        optionsMenu.SetActive(true);
        player.SetActive(true);
        BlinkingText.instance._StartCoroutine();
    }
}
