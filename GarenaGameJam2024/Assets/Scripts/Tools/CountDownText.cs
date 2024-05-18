using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using DG.Tweening;

public class CountDownText : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    void OnEnable()
    {
        
    }

    IEnumerator CountDown()
    {
        countdownText.transform.localScale = Vector3.one;
        countdownText.text = "3";
        countdownText.transform.DOScale(Vector3.one * 1.5f, 0.5f).SetLoops(2, LoopType.Yoyo);
        yield return new WaitForSeconds(1f);
        countdownText.text = "2";
        countdownText.transform.DOScale(Vector3.one * 1.5f, 0.5f).SetLoops(2, LoopType.Yoyo);
        yield return new WaitForSeconds(1f);
        countdownText.text = "1";
        countdownText.transform.DOScale(Vector3.one * 1.5f, 0.5f).SetLoops(2, LoopType.Yoyo);
        yield return new WaitForSeconds(1f);
        countdownText.text = "GO!";
        countdownText.transform.DOScale(Vector3.one * 1.7f, 0.75f);
        countdownText.DOFade(0f, 1f);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.StartGame();
    }

}
