using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Monster_Movement : MonoBehaviour
{
    Monster monster;
    [SerializeField] public float moveSpeed;
    [SerializeField] private Rigidbody2D rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        monster = GetComponent<Monster>();

        moveSpeed = monster.stat.movementSpeed;
    }
    public void FixedUpdate()
    {
        rigid.velocity = new Vector2(moveSpeed, 0);
    }

}
