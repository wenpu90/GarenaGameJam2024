using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class BossGamePlay : MonoBehaviour
{
    public static BossGamePlay Instance { get; set; }
    public Transform bossObject;
    public UnityEvent enterBossStageEvent;
    public Element.ElementType bossElement;
    public KeyCode p1Cannon;
    public KeyCode p2Cannon;
    public Animator player1;
    public Animator player2;

    public bool player1InTowerState;
    public bool player2InTowerState;

    public Player p1;
    public Player p2;

    public PlayerTower p1Tower;
    public PlayerTower p2Tower;

    public GameObject p1Victory;
    public GameObject p2Victory;

    public PlayerController playerController;

    public List<GameObject> maps = new List<GameObject>();
    public List<Color> bossState = new List<Color>();
    public SpriteRenderer spriteRenderer;
    [SerializeField] private float hp;
    public bool isDead = false;
    public Image hpImage;
    public float bossMaxHp = 30;
    public Player lastHitPlayer;
    public float HP {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            if (hp <= 0)
            {
                hp = 0;
                BossDead();
            }
            UpdateBossHealth();
        }
    }
    void Awake()
    {
        Instance = this;
        HP = bossMaxHp;
    }
    private void Start()
    {
        player1InTowerState = false;
        player2InTowerState = false;
        enterBossStageEvent?.Invoke();
        MonsterManager.Instance.DestroyAllMonster();
    }
    public void Update()
    {
        if (Input.GetKeyDown(p1Cannon))
        {
            player1InTowerState = !player1InTowerState;
            playerController.p1StopMovement = !!player1InTowerState;
            player1.Play(player1InTowerState?"Tower":"Idle");
            p1Tower.ShowElement(player1InTowerState);
        }
        if (Input.GetKeyDown(p2Cannon))
        {
            player2InTowerState = !player2InTowerState;
            playerController.p2StopMovement = !!player2InTowerState;
            player2.Play(player2InTowerState ? "Tower" : "Idle");
            p2Tower.ShowElement(player2InTowerState);
        }
        if (player1InTowerState)
        {
            P1Control();
        }
        if (player2InTowerState)
        {
            P2Control();
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
    public void ChangeElement(Element.ElementType _elementType)
    {
        bossElement = _elementType;
        for (int i = 0; i < maps.Count; i++)
        {
            maps[i].SetActive(i == (int)_elementType + 1);
            if(i == (int)_elementType)
            {
                spriteRenderer.color = bossState[i];
            }   
        }
    }

    public void GetDamage(Player player)
    {
        float damage = 0;
        switch (bossElement)
        {
            case Element.ElementType.Fire:
                damage += player.stat.attack;
                damage += (player.stat.movementSpeed * 2);
                damage += player.stat.health / 2;
                break;
            case Element.ElementType.Water:
                damage += player.stat.attack / 2;
                damage += player.stat.movementSpeed;
                damage += player.stat.health * 2;
                break;
            case Element.ElementType.Wood:
                damage += player.stat.attack * 2;
                damage += player.stat.movementSpeed / 2;
                damage += (player.stat.health / 2);
                break;
            case Element.ElementType.Normal:
                damage += player.stat.attack;
                damage += player.stat.health;
                damage += player.stat.movementSpeed;
                break;
        }
        lastHitPlayer = player;
        HP -= Mathf.Clamp(damage, 1, 100);
    }

    void P1Control()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            p1Tower.Shoot(Element.ElementType.Fire, p1);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            p1Tower.Shoot(Element.ElementType.Water, p1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            p1Tower.Shoot(Element.ElementType.Wood, p1);
        }
    }


    void P2Control()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            p2Tower.Shoot(Element.ElementType.Fire, p2);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            p2Tower.Shoot(Element.ElementType.Water, p2);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            p2Tower.Shoot(Element.ElementType.Wood, p2);
        }
    }

    public void UpdateBossHealth()
    {
        hpImage.DOFillAmount(hp / bossMaxHp, 1f);
    }

    public void BossDead()
    {
        if (isDead) return;
        isDead = true;
        if(lastHitPlayer == p1)
        {
            p1Victory.SetActive(true);
        }
        else
        {
            p2Victory.SetActive(true);
        }
        Debug.Log("BossDead");
    }
}
