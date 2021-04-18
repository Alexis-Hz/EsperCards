using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is the collection of all cards in the game. 
 * this collection should be instantiated on Start of the server/client so that we can
 * create cards and decks
 */
public class CardCollection : MonoBehaviour
{
    public GameObject SpellCardPrefab;

    public List<SpellSO> HollowSOList;
    public Dictionary<string, GameObject> HollowCollection;
    
    // Start is called before the first frame update
    void Start()
    {
        HollowCollection = new Dictionary<string, GameObject>();
        foreach (SpellSO o in HollowSOList)
        {
            GameObject card = Instantiate(SpellCardPrefab, new Vector2(0, 0), Quaternion.identity);
            card.GetComponent<HydrateCard>().Hydrate(o);
            HollowCollection.Add(o.getName(), card);
        }

    }

}
