using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OrbBullet : MonoBehaviour
{
    public Element.ElementType elementType;
    public List<GameObject> orbs = new List<GameObject>();
    public float damage;
    public Stat stat;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(BossGamePlay.Instance.bossObject.position, 1f).SetEase(Ease.Flash).OnComplete(OnReached);
    }

    public void Setup(Element.ElementType _elementType, Stat _stat)
    {
        stat = _stat;
        elementType = _elementType;
        for (int i = 0; i < orbs.Count; i++)
        {
            orbs[i].SetActive(i == (int)_elementType);
        }
    }

    void OnReached()
    {
        BossGamePlay.Instance.GetDamage(stat);
        BossGamePlay.Instance.ChangeElement(elementType);
        Destroy(gameObject);
    }
}
