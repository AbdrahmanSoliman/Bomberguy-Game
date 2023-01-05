using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    public GameObject winPanel;
    public TextMeshProUGUI winText;
    private GameObject playerWinner;

    public void CheckWinState()
    {
        int aLiveCount = 0;

        foreach(GameObject player in players)
        {
            if(player.activeSelf)
            {
                aLiveCount++;
                playerWinner = player;
            }
        }

        if(aLiveCount <= 1)
        {
            Invoke(nameof(WinPanel), 0f);
        }
    }

    void WinPanel()
    {
        winText.text = playerWinner.name + " wins!";
        winPanel.SetActive(true);
        Invoke(nameof(NewRound), 3f);
    }

    void NewRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
