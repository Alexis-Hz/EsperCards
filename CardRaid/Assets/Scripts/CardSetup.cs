using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CardSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //we need to remove and add a new network identity   
        Destroy(gameObject.GetComponent<NetworkIdentity>());
        //NetworkIdentity networkIdentity= gameObject.AddComponent(typeof(NetworkIdentity)) as NetworkIdentity;
    }
}
