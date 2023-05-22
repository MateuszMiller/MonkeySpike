using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public TextMeshProUGUI currencyText;
    public TextMeshProUGUI highscoreText;

    public void SetEndInfo(int currency, int highscore)
    {
        currencyText.SetText(currency.ToString());
        highscoreText.SetText("Highscore: " + highscore);
    }

    public void OnDead()
    {
        
        PlayerPrefs.SetInt("Currency", GameManager.Instance.currency);
        int currHighscore = PlayerPrefs.GetInt("Highscore", 0);
        if (GameManager.Instance.points > currHighscore)
        {
            PlayerPrefs.SetInt("Highscore", GameManager.Instance.points);
            currHighscore = GameManager.Instance.points;

        }
            
        SetEndInfo(GameManager.Instance.currency, currHighscore);

        gameObject.SetActive(true);
    }
    public void Replay(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
