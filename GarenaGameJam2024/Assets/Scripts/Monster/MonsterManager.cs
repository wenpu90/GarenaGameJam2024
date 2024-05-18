using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class MonsterManager : MonoBehaviour
{
    [SerializeField] Transform position;
    [SerializeField] GameObject monster;
    private void Awake()
    {
        position = transform;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            SummonMonster();
        }
    }
    private async void SummonMonster()
    {
        Instantiate(monster, position);
        await UniTask.Delay(3000);
    }
}
