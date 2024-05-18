using UnityEngine;
using Sirenix.OdinInspector;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] int playerRole;

    [SerializeField] Collider2D Hitbox;
    public bool isFinishAttack { get; private set; } = true;
    [SerializeField] float activeTime;
    [SerializeField] float cooldownTime;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletPool;
    [SerializeField] private int initailSize = 5;

    private List<GameObject> availableObjects = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < initailSize; i++)
        {
            GameObject go = Instantiate<GameObject>(bullet, this.transform.position + Vector3.right, Quaternion.identity, bulletPool.transform);
            availableObjects.Add(go);
            go.SetActive(false);
        }
    }

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
            var bullet = GetPooledInstance(bulletPool.transform);

            await UniTask.Delay((int)(activeTime * 1000));
            BackToPool(bullet);
        }
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
    public GameObject GetPooledInstance(Transform parent)
    {
        lock (availableObjects)
        {
            GameObject go;
            int lastIndex = availableObjects.Count - 1;
            if (lastIndex >= 0)
            {
                go = availableObjects[lastIndex];
                availableObjects.RemoveAt(lastIndex);
                go.SetActive(true);
                if (go.transform.parent != parent)
                {
                    go.transform.SetParent(parent);
                }
            }
            else
            {
                go = Instantiate<GameObject>(bullet, parent);
            }
            go.transform.position = this.transform.position + Vector3.right;
            return go;
        }
        
    }
    public void BackToPool(GameObject go)
    {
        lock (availableObjects)
        {
            availableObjects.Add(go);
            go.SetActive(false);
        }
    }
}
