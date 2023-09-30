using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject player;
    public GameObject deathMenu;
    public GameObject optionsMenu;
    public GameObject panelPrefab;
    public TextMeshProUGUI currencyText;

    public ShopButton[] shopButtons;
    public Skin[] skins;

    private void Start()
    {
        int equippedSkin = PlayerPrefs.GetInt("EquippedSkin", 0); 
        for (int i = 0; i < skins.Length; i++)
        {
            shopButtons[i].SetupSkin(skins[i]);
            if (skins[i].id == equippedSkin)
            {
                PlayerSkinController.Instance.SetSkin(skins[i]);
            }
            if (PlayerPrefs.GetInt($"Skin_{skins[i].id}", 0) == 1)
            {
                shopButtons[i].buyButton.SetActive(false);
            }
        }

    }

    public void ActivateShop()
    {
        if (shopPanel.gameObject.activeSelf)
        {
            DeactivateShop();
            return;
        }
        currencyText.SetText(GameManager.Instance.currency.ToString());
        deathMenu.SetActive(false);
        optionsMenu.SetActive(false);
        shopPanel.gameObject.SetActive(true);
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
