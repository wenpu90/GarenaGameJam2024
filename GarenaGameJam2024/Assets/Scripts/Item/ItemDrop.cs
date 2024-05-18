using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ItemDrop : MonoBehaviour
{
    public Element element_Prefab;

    private void Start()
    {
        if(TryGetComponent(out Monster monster))
        {
            monster.OnDeadEvent += DropItem;
        }
    }

    [Button]
    void DropItem(Monster monster)
    {
        Element element = Instantiate(element_Prefab.gameObject, transform.position, Quaternion.identity).GetComponent<Element>();
        element.SetupElement(monster.elementType);
    }
}
