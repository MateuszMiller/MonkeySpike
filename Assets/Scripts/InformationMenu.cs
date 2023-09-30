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

    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI darkHighScoreText;

    public TextMeshProUGUI deaths;
    public TextMeshProUGUI darkDeaths;

    public TextMeshProUGUI bananas;
    public TextMeshProUGUI darkBananas;

    public TextMeshProUGUI timePlayed;
    public TextMeshProUGUI darkTimePlayed;
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

        highScoreText.SetText("Highscore: " + PlayerPrefs.GetInt("Highscore", 0).ToString());
        darkHighScoreText.SetText("Highscore: " + PlayerPrefs.GetInt("DarkHighscore", 0).ToString());

        deaths.SetText("Total deaths: " + PlayerPrefs.GetInt("Deaths", 0).ToString());
        darkDeaths.SetText("Total deaths: " + PlayerPrefs.GetInt("DarkDeaths", 0).ToString());

        bananas.SetText("Total bananas colected: " + PlayerPrefs.GetInt("Bananas", 0).ToString());
        darkBananas.SetText("Total bananas colected: " + PlayerPrefs.GetInt("DarkBananas", 0).ToString());

        int playTimeSeconds = (int)PlayerPrefs.GetFloat("Playtime", 0);
        int playTimeSecondsDark = (int)PlayerPrefs.GetFloat("DarkPlaytime", 0);

        timePlayed.SetText("Total time played: " + playTimeSeconds + " seconds");
        darkTimePlayed.SetText("Total time played: " + playTimeSecondsDark + " seconds");



        //totalCurrencyText.SetText("Total bananas colected: " + GameManager.Instance.totalCurrency.ToString());
        //highScoreText.SetText("Highest score: " + GameManager.Instance.maxPoints.ToString());

    }
    public void DeactivateInfo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
