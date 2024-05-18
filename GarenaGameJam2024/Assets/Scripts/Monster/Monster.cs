using UnityEngine;
using System;
using Sirenix.OdinInspector;
using static Element;
using UnityEditor;

public class Monster : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] bool UseConstantElementType;
#endif
    public Element.ElementType elementType;
    public Stat stat;
    public Action<Monster> OnDeadEvent = delegate { };
    private void Awake()
    {
#if UNITY_EDITOR
        if (UseConstantElementType) return;
#endif
        elementType = (ElementType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(ElementType)).Length);
        Debug.Log(elementType);
    }
    [Button]
    public void TakeDamage(float damage)
    {
        stat.health -= damage;
        if (stat.health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        OnDeadEvent?.Invoke(this);
        MonsterManager.Instance.RandomSpawn();
        Destroy(gameObject);
    }
}
