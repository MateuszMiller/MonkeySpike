using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
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
    public TextMeshProUGUI currencyText;

    private void Start()
    {
        scoreText.SetText("" + points);
    }

    public void AddPoints()
    {
        points += 1;
        scoreText.SetText(""+points);
    }
    public void AddCurency()
    {
        currency += 1;
        currencyText.SetText("" + points);
    }
}
