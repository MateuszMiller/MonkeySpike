using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skins/New skin")]
public class Skin : ScriptableObject
{
    public int id;
    public int cost;
    public Sprite skinSprite;
}
