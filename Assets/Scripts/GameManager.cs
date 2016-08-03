using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    private int turnCount;
    private bool gameFinished;

    void Start ()
    {
        turnCount = 1;
        gameFinished = false;
    }

    void Update () {

        if (!gameFinished)
        {
            if ((turnCount % 2) == 0)
            {
                player1.GetComponent<PlayerController>().enabled = false;
                player1.transform.Find("ArrowImage").gameObject.SetActive(false);
                player2.GetComponent<PlayerController>().enabled = true;
                player2.transform.Find("ArrowImage").gameObject.SetActive(true);
            }

            else
            {
                player1.GetComponent<PlayerController>().enabled = true;
                player1.transform.Find("ArrowImage").gameObject.SetActive(true);
                player2.GetComponent<PlayerController>().enabled = false;
                player2.transform.Find("ArrowImage").gameObject.SetActive(false);
            }
        }

    }

    public void AddTurn()
    {
        turnCount++;
    }
}
