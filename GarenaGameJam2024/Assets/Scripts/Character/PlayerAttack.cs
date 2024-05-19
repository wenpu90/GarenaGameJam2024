using UnityEngine;
using Sirenix.OdinInspector;
using Cysharp.Threading.Tasks;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] int playerRole;

    [SerializeField] Collider2D Hitbox;
    public BulletsPool bulletPool;
    public bool isFinishAttack { get; private set; } = true;
    public bool isAttacking { get; private set; }
    [SerializeField] float activeTime;
    [SerializeField] float cooldownTime;

    [Button]
    public void Attack()
    {
        if (playerRole == 0) { MeleeAttack(); }
        if (playerRole == 1) { RemoteAttack(); }
    }
    public void MeleeAttack()
    {
        ActiveAttack();

        Cooldown();
    }

    public void RemoteAttack()
    {
        ActiveAttack();

        Cooldown();
    }
    public async void ActiveAttack()
    {
        isAttacking = true;
        if (playerRole == 0)
        {
            isFinishAttack = false;
            Hitbox.enabled = true;

            await UniTask.Delay((int)(activeTime * 1000));
            Hitbox.enabled = false;
        }
        else if (playerRole == 1)
        {
            isFinishAttack = false;
            var bullet = bulletPool.GetPooledInstance(bulletPool.transform);

            await UniTask.Delay((int)(activeTime * 1000));
            bulletPool.BackToPool(bullet);
        }
        isAttacking = false;
    }
    public async void Cooldown()
    {
        if (playerRole == 0)
        {
            await UniTask.Delay((int)(cooldownTime * 1000));
            isFinishAttack = true;
        }
        else if (playerRole == 1)
        {
            await UniTask.Delay((int)(cooldownTime * 1000));
            isFinishAttack = true;
        }
    }
    public void DisabledHitbox()
    {
        Hitbox.enabled = false;
    }
}
