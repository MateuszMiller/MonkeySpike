using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinController : MonoBehaviour
{
    public static PlayerSkinController Instance;

    private SpriteRenderer _rend;

    private void Awake()
    {
        Instance = this;
        _rend = GetComponent<SpriteRenderer>();
    }

    public void SetSkin(Skin skin)
    {
        _rend.sprite = skin.skinSprite;
        PlayerPrefs.SetInt("EquippedSkin", skin.id);
    }
}
