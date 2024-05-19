using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Stat defaultStat;
    public Stat stat;
    private float currentHp;
    public bool isDead = false;
    [SerializeField] private GameObject pos;
    public PlayerUI playerUI;
    private Vector3 presetScale;
    private void Awake()
    {
        currentHp = stat.health;
    }

    void Start()
    {
        UpdateElement();
        UpdateHealth();
    }
    [Button]
    public void TakeDamage(float damage)
    {
        if (isDead) return;
        currentHp -= damage;
        UpdateHealth();
        if (currentHp <= 0) Die();
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
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        playerUI.UpdateHealth(currentHp / stat.health);
    }
    public void UpdateElement()
    {
        
        playerUI.UpdateElement(this);
    }
}
