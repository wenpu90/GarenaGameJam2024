using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public GameMenu gameMenu;
    public Tutorial tutorial;
    public Gameplay gameplay;

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

        //if (Input.GetKeyDown(KeyCode.F1))
        //{
        //    gameMenu.gameObject.SetActive(true);
        //}
    }
}
