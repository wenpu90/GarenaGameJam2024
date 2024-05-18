using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

public class Platform : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public Ease ease;
    public float duration = 1f;

    void OnEnable()
    {
        transform.position = startPos;
        transform.DOMove(endPos, duration).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
    }

    [Button]
    void SetStartPos()
    {
        startPos = transform.position;
    }

    [Button]
    void SetEndPos()
    {
        endPos = transform.position;
    }

    [Button]
    void BackToStartPos()
    {
        transform.position = startPos;
    }
}
