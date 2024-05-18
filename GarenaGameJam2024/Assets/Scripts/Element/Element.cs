using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public enum ElementType { Fire, Water, Wood }
    public ElementType elementType;
    public int elementPoint;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null)
        {
            if(collision.attachedRigidbody.TryGetComponent(out Player player))
            {
                switch (elementType)
                {
                    case ElementType.Fire:
                        player.stat.attack += elementPoint;
                        break;
                    case ElementType.Water:
                        player.stat.movementSpeed += elementPoint;
                        break;
                    case ElementType.Wood:
                        player.stat.health += elementPoint;
                        break;
                }
            }
        }
           
    }
}
