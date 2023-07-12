using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public TextMeshProUGUI currencyText;
    public TextMeshProUGUI highscoreText;

    public Shop shopScript;

    public int currHighscore;
    public int currHighscoreDark;
    public void SetEndInfo(int currency, int highscore)
    {
        currencyText.SetText(currency.ToString());
        highscoreText.SetText("Highscore: " + highscore.ToString());
    }

    public void OnDead()
    {
        int tmpPoints = GameManager.Instance.points;
        int tmpCurrency = GameManager.Instance.currency;

        int deaths = PlayerPrefs.GetInt("Deaths", 0);
        int darkDeaths = PlayerPrefs.GetInt("DarkDeaths", 0);

        int bananasCol = PlayerPrefs.GetInt("Bananas", 0);
        int darkBananasCol = PlayerPrefs.GetInt("DarkBananas", 0);

        float playtime = PlayerPrefs.GetFloat("Playtime", 0);
        float darkPlaytime = PlayerPrefs.GetFloat("DarkPlaytime", 0);

        PlayerPrefs.SetInt("Currency", tmpCurrency);

        currHighscore = PlayerPrefs.GetInt("Highscore", 0);
        currHighscoreDark = PlayerPrefs.GetInt("DarkHighscore", 0);
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (tmpPoints > currHighscore)
            {
                currHighscore = tmpPoints;
                PlayerPrefs.SetInt("Highscore", currHighscore);
            }

            deaths += 1;
            PlayerPrefs.SetInt("Deaths", deaths);

            bananasCol += GameManager.Instance.bananasColected;
            PlayerPrefs.SetInt("Bananas", bananasCol);

            playtime += GameManager.Instance.timePlayed;
            PlayerPrefs.SetFloat("Playtime", playtime);

            SetEndInfo(tmpCurrency, currHighscore);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (tmpPoints > currHighscoreDark)
            {
                currHighscoreDark = tmpPoints;
                PlayerPrefs.SetInt("DarkHighscore", currHighscoreDark);
            }

            darkDeaths += 1;
            PlayerPrefs.SetInt("DarkDeaths", darkDeaths);

            darkBananasCol += GameManager.Instance.darkBananasColected;
            PlayerPrefs.SetInt("DarkBananas", darkBananasCol);

            darkPlaytime += GameManager.Instance.timePlayed;
            PlayerPrefs.SetFloat("DarkPlaytime", darkPlaytime);

            SetEndInfo(tmpCurrency, currHighscoreDark);
        }
        
        gameObject.SetActive(true);
    }

    public void GetToShop()
    {
        gameObject.SetActive(false);
        shopScript.ActivateShop();
    }
    public void Replay(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
