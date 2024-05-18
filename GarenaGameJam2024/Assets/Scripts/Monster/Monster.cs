using UnityEngine;
using System;
using Sirenix.OdinInspector;
using static Element;
using UnityEditor;

public class Monster : MonoBehaviour
{
    public Element.ElementType elementType;
    public Stat stat;
    public Action<Monster> OnDeadEvent = delegate { };
    private void Awake()
    {
        elementType = (ElementType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(ElementType)).Length);
        Debug.Log(elementType);
        var sprite = GetComponent<SpriteRenderer>();
        switch (elementType)
        {
            case ElementType.Fire:
                sprite.color = new Color(1, 0, 0, 1);
                break;
            case ElementType.Water:
                sprite.color = new Color(0, 0, 1, 1);
                break;
            case ElementType.Wood:
                sprite.color = new Color(0, 1, 0, 1);
                break;
        }
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();
            if (player) player.TakeDamage(this.stat.attack);
        }
    }
}
