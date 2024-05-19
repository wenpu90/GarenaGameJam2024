using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BossGamePlay : MonoBehaviour
{
    public UnityEvent enterBossStageEvent;
    public Element.ElementType bossElement;
    public KeyCode p1Cannon;
    public KeyCode p2Cannon;
    public Animator player1;
    public Animator player2;

    public bool player1InTowerState;
    public bool player2InTowerState;

    public PlayerController playerController;

    public List<GameObject> maps = new List<GameObject>();
    private void Start()
    {
        player1InTowerState = false;
        player2InTowerState = false;
        enterBossStageEvent?.Invoke();
    }
    public void Update()
    {
        if (Input.GetKeyDown(p1Cannon))
        {
            player1InTowerState = !player1InTowerState;
            playerController.p1StopMovement = !!player1InTowerState;
            player1.Play(player1InTowerState?"Tower":"Idle");
        }
        if (Input.GetKeyDown(p2Cannon))
        {
            player2InTowerState = !player2InTowerState;
            playerController.p2StopMovement = !!player2InTowerState;
            player2.Play(player2InTowerState ? "Tower" : "Idle");
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            ChangeElement(Element.ElementType.Normal);
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            ChangeElement(Element.ElementType.Fire);
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            ChangeElement(Element.ElementType.Water);
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            ChangeElement(Element.ElementType.Wood);
        }
    }

    [Button]
    public void ChangeElement(Element.ElementType elementType)
    {
        bossElement = elementType;
        for (int i = 0; i < maps.Count; i++)
        {
            maps[i].SetActive(i == (int)elementType);
        }
    }
}
