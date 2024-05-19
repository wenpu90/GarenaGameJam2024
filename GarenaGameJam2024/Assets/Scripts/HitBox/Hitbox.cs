using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] Monster monster;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            monster = collision.GetComponentInParent<Monster>();
            monster.TakeDamage(player.stat.attack);
        }
        else if (collision.CompareTag("Boss"))
        {
            BossGamePlay.Instance.GetDamage(player.stat);
        }
    }
}
