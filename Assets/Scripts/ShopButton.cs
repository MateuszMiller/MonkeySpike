using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public Image skinImage;
    public GameObject buyButton;

    private Skin _skin;

    public void SetupSkin(Skin skin)
    {
        _skin = skin;
        skinImage.sprite = skin.skinSprite;
    }

    public void BuySkin()
    {
        if(GameManager.Instance.currency < _skin.cost)
        {
            return;
        }
        GameManager.Instance.AddCurrency(-_skin.cost);
        PlayerPrefs.SetInt($"Skin_{_skin.id}", 1);
        buyButton.SetActive(false);
    }

    public void EquipSkin()
    {
        PlayerSkinController.Instance.SetSkin(_skin);
    }
}
