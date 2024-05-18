using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid;

    [Header("運動參數")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float maxAccelecration = 50f; //最大加速度
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float airControl = .5f; //空中控制力
    [SerializeField] private float gravity = 9.8f;

    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float groundCheckDistance = .1f;
    [SerializeField] private float footHeightOffset = 0;

    [SerializeField] private bool showDebug = true;

    private int moveDirection;
    public bool isJumping = false; //正在跳躍(上升時)
    public bool isGround = true;
    public bool isMoving => _tmpMove != 0;
    private float _tmpMove = 0;
    private Vector2 _tmpVelocity;

    public Vector2 Velocity => rigid.velocity;

    private void Start()
    {
        rigid.gravityScale = 0;
    }
    public void Move(float move)
    {
        _tmpMove = move;
    }

    private void FixedUpdate()
    {
        CheckGround();
        DoJump();
        Flip();

        if (isGround)
        {
            var tmpVelocity = rigid.velocity;
            tmpVelocity.y = 0;
            rigid.velocity = tmpVelocity;
            GroundMove(_tmpMove);
        }
        else
        {
            AirMove(_tmpMove);
        }
    }
    private void Flip()
    {
        this.transform.localScale = moveDirection == 0 ? this.transform.localScale : new Vector3(moveDirection, 1, 1);
    }

    public void GroundMove(float move)
    {
        _tmpVelocity = rigid.velocity;

        moveDirection = Mathf.Sign(move) > 0 ? 1 : -1;
        if (move == 0)
            moveDirection = 0;

        var targetVelocity = moveSpeed * moveDirection;

        var speedChange = maxAccelecration * Time.deltaTime;
        _tmpVelocity.x = Mathf.MoveTowards(_tmpVelocity.x, targetVelocity, speedChange);
        rigid.velocity = _tmpVelocity;

        if (showDebug)
            Debug.DrawRay(transform.position, Vector2.right * targetVelocity, Color.green);
    }

    public void AirMove(float move)
    {
        _tmpVelocity = rigid.velocity;

        moveDirection = Mathf.Sign(move) > 0 ? 1 : -1;
        if (move == 0)
            moveDirection = 0;

        var targetVelocity = moveSpeed * moveDirection;
        var speedChange = maxAccelecration * Time.deltaTime * airControl;

        _tmpVelocity.x = Mathf.MoveTowards(_tmpVelocity.x, targetVelocity, speedChange);

        rigid.velocity = _tmpVelocity;
        rigid.velocity += Vector2.down * (gravity * Time.deltaTime);
    }

    public void Jump()
    {
        isJumping = true;
    }
    private void DoJump()
    {
        if (!isJumping) return;
        if (isGround)
        {
            isGround = false;
            var jumpF = rigid.velocity;
            jumpF.y += jumpForce;
            rigid.velocity = jumpF;
        }
        else
        {
            if (rigid.velocity.y < jumpForce * .5f) 
                isJumping = false;
        }
    }

    private void CheckGround()
    {
        if (isJumping) return;
        isGround = false;
        
        var hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayerMask);
        if (hit.collider != null)
        {
            isGround = true;
            AttachGround(hit.point);
        }
        if (showDebug)
            Debug.DrawRay(hit.point, hit.normal, isGround ? Color.blue : Color.yellow);
    }

    private void AttachGround(Vector2 hitPoint)
    {
        rigid.position = hitPoint + footHeightOffset * Vector2.up;
    }
    private void OnGUI()
    {
        if (showDebug)
        {
            Rect rect = new Rect(200, 150, 200, 200);

            string message = "_isGround : " + isGround + "\n" +
                                "_isJumping" + isJumping + "\n";

            GUIStyle style = new GUIStyle();
            style.fontSize = 50;
            style.fontStyle = FontStyle.Bold;
            style.normal.textColor = Color.white;

            GUI.Label(rect, message, style);

        }
    }
}
