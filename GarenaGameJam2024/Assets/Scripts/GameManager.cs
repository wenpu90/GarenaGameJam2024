using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public GameMenu gameMenu;
    public Tutorial tutorial;
    public Gameplay gameplay;
    public BossGamePlay bossGamePlay;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.F1))
        {
            StartBossFight();
        }
    }

    public void StartGame()
    {
        gameplay.gameObject.SetActive(true);
    }

    public void StartBossFight()
    {
        bossGamePlay.gameObject.SetActive(true);
    }
}
