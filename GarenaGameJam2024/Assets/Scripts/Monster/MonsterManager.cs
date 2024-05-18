using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class MonsterManager : MonoBehaviour
{
    [SerializeField] Vector3 position;
    [SerializeField] GameObject monster1;
    [SerializeField] GameObject monster2;
    [SerializeField] RandomSpawn randomSpawn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            SummonMonster();
        }
    }
    private async void SummonMonster()
    {
        int index = randomSpawn.GetRandomIndex();
        var monster = randomSpawn.GetFace(index) > 0 ? monster1 : monster2;
        Instantiate(monster, randomSpawn.GetPosition(index), Quaternion.identity);
        await UniTask.Delay(3000);
    }
}
