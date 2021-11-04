using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalStateManager : MonoBehaviour
{
    public Text winnerMsg;
    public GameObject gameoverPanel;

    private int deadPlayers = 0;
    private int deadPlayerNumber = -1;
    public void PlayerDied(int playerNumber)
    {
        deadPlayers++;

        if (deadPlayers == 1)
        {
            deadPlayerNumber = playerNumber;
            Invoke(nameof(CheckPlayersDeath), .3f);
        }
    }

    private void CheckPlayersDeath()
    {
        string msg = deadPlayers == 1 ? deadPlayerNumber != 1 ? "Победил 1 игрок!" : "Победил 2 игрок!" : "Ничья!";
        Debug.Log(msg);
        winnerMsg.text = msg;
        gameoverPanel.SetActive(true);
    }
}
