using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AutoFade : MonoBehaviour
{
    public Image image;
    void OnEnable()
    {
        image.DOFade(0f, 0f);
        image.DOFade(1f, 1f);
    }
}
