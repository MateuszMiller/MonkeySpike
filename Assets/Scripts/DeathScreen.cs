using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public TextMeshProUGUI currencyText;
    public TextMeshProUGUI highscoreText;

    public Shop shopScript;

    public int currHighscore;
    
    public void SetEndInfo(int currency, int highscore)
    {
        
        currencyText.SetText(currency.ToString());
        highscoreText.SetText("Highscore: " + highscore.ToString());
    }

    public void OnDead()
    {

        int tmpPoints = GameManager.Instance.currency;
        int tmpCurrency = GameManager.Instance.currency;

        PlayerPrefs.SetInt("Currency", tmpCurrency);

        currHighscore = PlayerPrefs.GetInt("Highscore", 0);
        if (tmpPoints > currHighscore)
        {
            currHighscore = tmpPoints;
            PlayerPrefs.SetInt("Highscore", currHighscore);
          
        }
        
        SetEndInfo(tmpCurrency, currHighscore);

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
