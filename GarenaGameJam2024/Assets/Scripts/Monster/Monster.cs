using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Monster : MonoBehaviour
{
    public Stat stat;
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
        Destroy(gameObject);
    }
}
