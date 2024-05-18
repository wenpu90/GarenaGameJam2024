using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameMenu : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public void StartGame()
    {
        canvasGroup.DOFade(0f, 1f);
    }
}
