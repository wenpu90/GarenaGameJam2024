using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Monster_Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {
        rigid.velocity = new Vector2(moveSpeed, 0);
    }

}
