using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class GameMenu : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public bool isPressed = false;
    public TextMeshProUGUI pressAnyKey;

    void Start()
    {
        pressAnyKey.DOFade(0.2f, 1f).SetLoops(-1, LoopType.Yoyo);
    }
    public void StartGame()
    {
        canvasGroup.DOFade(0f, 1f);
        pressAnyKey.DOFade(0f, 1f);
    }

    void Update()
    {
        if (isPressed) return;
        if (Input.anyKeyDown)
        {
            StartGame();
        }
    }

}
