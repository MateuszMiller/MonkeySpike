using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public int currency;
    public int points;

    public TextMeshProUGUI scoreText;
    public int maxPoints;
    public int highscore;

    public int bananasColected;
    public int darkBananasColected;

    public float timePlayed;

    public int skinID;

    private void Start()
    {
        AddCurrency(PlayerPrefs.GetInt("Currency", 0));
        
        scoreText.SetText("" + points);
    }
   
    
    public void AddPoints()
    {
        points += 1;
        scoreText.SetText(""+points);

    }
    
    public void AddCurrency(int diff)
    {
        currency += diff;
        PlayerPrefs.SetInt("Currency", currency);
    }

    public void ChangeMode()
    {
        int sceneIndexToLoad = SceneManager.GetActiveScene().buildIndex == 0 ? 1 : 0;
        SceneManager.LoadScene(sceneIndexToLoad);
    }
}
