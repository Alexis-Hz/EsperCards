using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DrawCards : NetworkBehaviour
{
    public PlayerManager PlayerManager;
    public Orchestrator Orchestrator;

    public void OnClick()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();
        Orchestrator = PlayerManager.GetComponent<Orchestrator>();
        PlayerManager.CmdDealCards();
        Orchestrator.CmdStartClock();
    }
}
