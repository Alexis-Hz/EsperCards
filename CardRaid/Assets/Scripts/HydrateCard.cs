using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HydrateCard : MonoBehaviour
{
    public SpellCard spellCard;

    public Text timeText;
    public Text nameText;
    public Text textText;
    public Text attackText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("AttackSpellCard").GetComponent<Image>().sprite = spellCard.cardImage;
        timeText.text = spellCard.cardTime.ToString();
        nameText.text = spellCard.cardName;
        textText.text = spellCard.cardText;
        attackText.text = spellCard.cardAttack.ToString();

    }
}
