using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDamage = 1f;

    void Awake()
    {
        Destroy(gameObject, 3f);
    }
    private void FixedUpdate()
    {
        transform.Translate(transform.right * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();
            if (player) player.TakeDamage(bulletDamage);
        }
    }
}
