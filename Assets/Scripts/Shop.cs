using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public GameObject panelPrefab;

    public GameObject player;

    public GameObject deathMenu;

    public TextMeshProUGUI currencyText;

    public GameObject optionsMenu;

    public void Buy(SkinsScriptableObject skin)
    {
        if (GameManager.Instance.currency >= skin.prize)
        {
            player.GetComponent<SpriteRenderer>().sprite = skin.skinImage;
            GameManager.Instance.AddCurrency(-skin.prize);
        }
        
    }

    public void ActivateShop()
    {
        if (gameObject.activeSelf)
        {
            DeactivateShop();
            return;
        }
        currencyText.SetText(GameManager.Instance.currency.ToString());
        deathMenu.SetActive(false);
        optionsMenu.SetActive(false);
        gameObject.SetActive(true);
        if(player != null)
        {
            player.SetActive(false);
        }
       
    }
    public void DeactivateShop()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
}
