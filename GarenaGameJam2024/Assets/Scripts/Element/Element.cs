using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class Element : MonoBehaviour
{
    public enum ElementType { Fire, Water, Wood, Normal }
    public ElementType elementType;
    public int elementPoint;
    public List<GameObject> orbs = new List<GameObject>();
    public AudioSource audioSource;
    public Rigidbody2D rigidbody2D;
    public BoxCollider2D boxCollider2D;
    public bool isOnFloor = false;
    public float dropForce = 1f;
    
    private void Start()
    {
        rigidbody2D.AddForce(Vector2.up * dropForce);
    }
    public void SetupElement(ElementType elementType)
    {
        orbs[(int)elementType].gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            isOnFloor = true;
            boxCollider2D.isTrigger = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOnFloor) return;
        if (collision.TryGetComponent(out Player player))
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
            player.UpdateElement();
            audioSource.Play();
            orbs.ForEach(n => n.gameObject.SetActive(false));
            GetComponent<BoxCollider2D>().enabled = false;
            Invoke("DelayDestroy", 2f);
        }

    }

    void DelayDestroy()
    {
        Destroy(gameObject);
    }
}
