using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Cards/Spell")]
public class SpellSO : ScriptableObject
{
    [SerializeField]
    public string cardName;
    [SerializeField]
    public int cardTime;
    [SerializeField]
    public string cardType;
    [SerializeField]
    public string cardClass;
    [SerializeField]
    public string cardText;

    [SerializeField]
    public int cardAttack;
    [SerializeField]
    public int cardBreak;
    [SerializeField]
    public int cardGuard;

    [SerializeField]
    public Sprite cardImage;

    public string getName()
    {
        return cardName;
    }
}