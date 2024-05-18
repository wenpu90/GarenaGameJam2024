using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnPlaces = new List<GameObject>();

    public int GetRandomIndex()
    {
        int x = Random.Range(0, spawnPlaces.Count);
        Debug.Log(spawnPlaces[x]);
        return x;
    }
    public Vector3 GetPosition(int x)
    {
        return spawnPlaces[x].transform.position;
    }
    public float GetFace(int x)
    {
        return spawnPlaces[x].transform.localScale.x;
    }
}
