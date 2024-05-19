using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Sirenix.OdinInspector;

public class Gameplay : MonoBehaviour
{
    public float enterBossStageTime = 60;
    public float currentTime = 60f;
    public TextMeshProUGUI countdownText;
    public bool ended;

    void Start()
    {
        currentTime = enterBossStageTime;
    }

    void Update()
    {
        if (ended) return;
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime = 0;
            EnterBossStage();
        }
        countdownText.text = currentTime.ToString("00");
    }
    [Button]

    void EnterBossStage()
    {
        ended = true;
        GameManager.Instance.StartBossFight();
    }
}
