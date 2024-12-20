using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    public GameObject Clock;
    public GameObject CardCollection;
    public GameObject PlayerDeck;
    public DeckController DeckController;

    List<GameObject> cards = new List<GameObject>();

    public GameObject DropZone;
    
    //Runtime Prefabs

    [SyncVar]
    int cardsPlayed = 0;
    // Start is called before the first frame update
    public override void OnStartClient()
    {
        base.OnStartClient();

        PlayerArea = GameObject.Find("PlayerArea");
        EnemyArea = GameObject.Find("EnemyArea");
        DropZone = GameObject.Find("DropZone");
        Clock = GameObject.Find("Clock");
        CardCollection = GameObject.Find("CardCollection");
        PlayerDeck = GameObject.Find("PlayerDeck");
        DeckController = PlayerDeck.GetComponent<DeckController>();
        DeckController.CreateStarterDeck(null, CardCollection.GetComponent<CardCollection>());
    }

    [Server]
    public override void OnStartServer()
    {
        //ClientScene.RegisterPrefab()
        cards.Add(Card1);
        cards.Add(Card2);
    }

    [Command]
    public void CmdDealCards()
    {
        PlayerHand hand = PlayerArea.GetComponent<PlayerHand>();
        for (int i = 0; i < hand.cardsToFullHand(); i++)
        {
            GameObject card = DeckController.drawCard();
            Debug.Log("Got Card");
            NetworkServer.Spawn(card, connectionToClient);
            Debug.Log("Spawned cards");
            RpcShowCard(card, "Dealt");
        }
        Debug.Log("Finished Drawing Cards");
        /*
        for (int i = 0; i < 5; i++)
        {
            GameObject card = Instantiate(cards[Random.Range(0, cards.Count)], new Vector2(0,0), Quaternion.identity);
            //create a card on every client so that everyone can see it
            NetworkServer.Spawn(card, connectionToClient);
            RpcShowCard(card, "Dealt");
        }
        */
    }

    public void PlayCard(GameObject card)
    {        
        CmdPlayCard(card);
        cardsPlayed++;
        //Debug.Log("CardsPlayed=" + cardsPlayed);
    }

    [Command]
    void CmdPlayCard(GameObject card)
    {
        RpcShowCard(card, "Played");
    }

    [ClientRpc]
    void RpcShowCard(GameObject card, string type)
    {
        if(type == "Dealt")
        {
            if(hasAuthority)
            {
                card.transform.SetParent(PlayerArea.transform, false);
            }
            else
            {
                card.transform.SetParent(EnemyArea.transform, false);
                card.GetComponent<CardFlipper>().Flip();
            }
        }
        else if(type == "Played")
        {
            card.transform.SetParent(DropZone.transform, false);
            if(!hasAuthority)
            {
                card.GetComponent<CardFlipper>().Flip();
            }
        }
    }

}
