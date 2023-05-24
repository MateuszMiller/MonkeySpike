using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject panelPrefab;

    public GameObject player;

    public void Buy(SkinsScriptableObject skin)
    {
        if (GameManager.Instance.currency >= skin.prize)
        {
            player.GetComponent<SpriteRenderer>().sprite = skin.skinImage;
            GameManager.Instance.AddCurrency(-skin.prize);
        }
        
    }
}
