using Cysharp.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Stat stat;
    private float currentHp;
    public bool isDead = false;
    [SerializeField] private GameObject pos;
    private void Awake()
    {
        currentHp = stat.health;
    }
    public void TakeDamage(float damage)
    {
        if (isDead) return;
        currentHp -= damage;
        if (currentHp < 0) Die();
    }
    private async void Die() 
    {
        isDead = true;
        await UniTask.Delay(5000);
        Resurrection();
    }
    private void Resurrection()
    {
        transform.position = pos.transform.position;
        isDead = false;
        currentHp = stat.health;
    }
}
