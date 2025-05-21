using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public OrbSpawner orbSpawner;
    public GameObject winCanvas;
    public GameObject loseCanvas;
    
    public float delayBeforeCheck = 2.0f;
    private float startTime;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        startTime = Time.time;
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Time.time - startTime > delayBeforeCheck)
        {
            CheckGameStatus();
        }
    }


    public void CheckGameStatus()
    {
        float orbCount = GameObject.FindGameObjectsWithTag("Orb").Length;
        float ghostCount = GameObject.FindGameObjectsWithTag("Ghost").Length;

        if (orbCount <= 0)
        {
            LoseGame();
        }

        if (ghostCount <= 0)
        {
            WinGame();
        }
        
    }

    public void WinGame()
    {
        winCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoseGame()
    {
        loseCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}
