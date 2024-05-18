using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance { get; set; } 
    [SerializeField] Vector3 position;
    [SerializeField] GameObject monster1;
    [SerializeField] GameObject monster2;
    [SerializeField] RandomSpawn randomSpawn;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        RandomSpawn();
        RandomSpawn();
        SummonMonster();
    }
    private async void SummonMonster()
    {
        RandomSpawn();
        await UniTask.Delay(5000);
        SummonMonster();
    }
    public void RandomSpawn()
    {
        Debug.Log("RandomSpawn");
        int index = randomSpawn.GetRandomIndex();
        var monster = randomSpawn.GetFace(index) > 0 ? monster1 : monster2;
        Instantiate(monster, randomSpawn.GetPosition(index), Quaternion.identity);
    }
}
