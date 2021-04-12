using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
/*
 * The Card orchestrator manages the card schedule and the in game timer.
 */
public class Orchestrator : NetworkBehaviour
{
    [SyncVar(hook = nameof(SetTime))]
    private int Time = 12;
    private float DeltaDuration = 5.0f;
    [SyncVar]
    private bool isRunning;

    public GameObject Clock;

    [Command]
    public void CmdStartClock()
    {
        if (!isRunning)
        {
            InvokeRepeating("Tick", 0f, DeltaDuration);
            isRunning = true;
        }
    }

    [Server]
    private void Tick()
    {
        if (Time == 12)
        {
            Time = 1;
        }
        else
        {
            Time++;
        }
    }
    void SetTime(int oldTime, int newTime)
    {
        GameObject.Find("ClockNumber").GetComponent<Text>().text = newTime.ToString();
        string clockNameNew = "T" + newTime.ToString();
        string clockNameOld = "T" + oldTime.ToString();
        GameObject.Find(clockNameNew).GetComponent<Image>().color = Color.magenta;
        GameObject.Find(clockNameOld).GetComponent<Image>().color = Color.white;
    }
}
    
