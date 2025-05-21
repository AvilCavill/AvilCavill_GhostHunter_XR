using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public OrbSpawner orbSpawner;
    public GameObject winCanvas;
    public GameObject loseCanvas;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
    }

    // public IEnumerator  CheckGameStatus()
    // {
    //     // Espera a que el OrbSpawner haya empezado
    //     yield return new WaitUntil(() => orbSpawner.HasStartedSpawning);
    //
    //     while (true)
    //     {
    //         int activeOrbs = GameObject.FindGameObjectsWithTag("Orb").Length;
    //         int activeGhosts = GameObject.FindGameObjectsWithTag("Ghost").Length;
    //
    //         // Solo pierdes si no hay orbes Y ya se spawnearon todos
    //         if (activeOrbs == 0 && orbSpawner.HasFinishedSpawning)
    //         {
    //             LoseGame();
    //             yield break;
    //         }
    //         else if (activeGhosts == 0)
    //         {
    //             WinGame();
    //             yield break;
    //         }
    //
    //         yield return new WaitForSeconds(0.5f);
    //     }
    // }


    public void WinGame()
    {
        winCanvas.SetActive(true);
    }

    public void LoseGame()
    {
        loseCanvas.SetActive(true);
    }
}
