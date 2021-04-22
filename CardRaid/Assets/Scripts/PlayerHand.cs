using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public int cardsInHand;
    public int handLimit;

    private void Start()
    {
        cardsInHand = 0;
        handLimit = 6;
    }
    
    public int cardsToFullHand()
    {
        return handLimit - cardsInHand;
    }

    public void increaseHand(int cardCount)
    {
        cardsInHand += cardCount;
    }
}
