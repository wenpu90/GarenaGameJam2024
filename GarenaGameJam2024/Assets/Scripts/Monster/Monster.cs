using UnityEngine;
using UnityEngine.InputSystem.Processors;
using System;
using Sirenix.OdinInspector;

public class Monster : MonoBehaviour
{
    public Element.ElementType elementType;
    public Stat stat;
    public Action<Monster> OnDeadEvent = delegate { };

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
        Destroy(gameObject);
    }
}
