using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckController : MonoBehaviour
{
    public int deckSize;
    public ArrayList deck;

    public void CreateStarterDeck(ClassSO HeroClass, CardCollection cardCollection)
    {
        deck = new ArrayList();
        //create the default deck for the class, i will add thhis to the class prefab later
        for(int i = 0; i <3; i++)
        {
            GameObject card = Instantiate(cardCollection.HollowCollection["Slash"]);
            deck.Add(card);
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject card = Instantiate(cardCollection.HollowCollection["Jump"]);
            deck.Add(card);
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject card = Instantiate(cardCollection.HollowCollection["Ascension"]);
            deck.Add(card);
        }
        //ShuffleDeck();
        updateDeckSizeText(deck.Count);
    }

    public void ShuffleDeck()
    {
        for(int i = 0; i< deck.Count; i++)
        {
            int at = Random.Range(0, deck.Count);
            var tempSwap = deck[at];
            deck.RemoveAt(at);
            deck.Add(tempSwap);
        }
        foreach(GameObject go in deck)
        {
            Debug.Log("Card:" + go.GetComponent<HydrateCard>().nameText.text);
        }
    }

    public GameObject drawCard()
    {
        GameObject card = (GameObject)deck[0];
        deck.RemoveAt(0);
        return card;
    }

    public void updateDeckSizeText(int size)
    {
        GameObject.Find("CardCountText").GetComponent<Text>().text = size.ToString();
    }

    //this will be used once we have saved states
    public void LoadExistingDeck()
    {

    }
}
