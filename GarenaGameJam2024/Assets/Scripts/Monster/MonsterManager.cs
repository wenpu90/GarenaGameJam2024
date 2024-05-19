using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance { get; set; } 
    [SerializeField] Vector3 position;
    [SerializeField] GameObject monster1;
    [SerializeField] GameObject monster2;
    [SerializeField] RandomSpawn randomSpawn;
    public List<Monster> monsters = new List<Monster>();
    public bool stopSpawn;

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
        if (stopSpawn) return;
        //Debug.Log("RandomSpawn");
        int index = randomSpawn.GetRandomIndex();
        var monster = randomSpawn.GetFace(index) > 0 ? monster1 : monster2;
        Monster mons = Instantiate(monster, randomSpawn.GetPosition(index), Quaternion.identity).GetComponent<Monster>();
        monsters.Add(mons);
    }
    [Button]

    public void DestroyAllMonster()
    {
        stopSpawn = true;
        enabled = false;
        for (int i = 0; i < monsters.Count; i++)
        {
            if(monsters[i] != null)
            {
                monsters[i].Die();
            }
        }
    }
}
