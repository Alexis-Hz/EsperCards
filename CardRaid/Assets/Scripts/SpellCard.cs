using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/SpellCard")]
public class SpellCard : ScriptableObject
{
    public string cardName;
    public int cardTime;
    public string cardType;
    public string cardClass;
    public string cardText;

    public int cardAttack;
    public int cardBreak;
    public int cardGuard;

    public Sprite cardImage;
}
