using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletParent;
    [SerializeField] private int initailSize = 5;
    private List<GameObject> availableObjects = new List<GameObject>();
    private void Awake()
    {
        for (int i = 0; i < initailSize; i++)
        {
            GameObject go = Instantiate<GameObject>(bullet, this.transform.position + Vector3.right + Vector3.up, Quaternion.identity, bulletParent.transform);
            availableObjects.Add(go);
            go.SetActive(false);
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
            go.transform.position = this.transform.position + Vector3.right + Vector3.up;
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
