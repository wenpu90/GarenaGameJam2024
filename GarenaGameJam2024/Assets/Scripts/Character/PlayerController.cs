using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] bool showDebug;
    [SerializeField] PlayerInput input;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    [SerializeField] EnemyDetector player1EnemyDectector;
    [SerializeField] EnemyDetector player2EnemyDectector;

    PlayerMovement player1Movement;
    PlayerMovement player2Movement;

    PlayerAttack player1Attack;
    PlayerAttack player2Attack;

    PlayerAnimationPlayer player1Animation;
    PlayerAnimationPlayer player2Animation;
    private void Awake()
    {
        player1Movement = player1.GetComponent<PlayerMovement>();
        player2Movement = player2.GetComponent<PlayerMovement>();

        player1Attack = player1.GetComponent<PlayerAttack>();
        player2Attack = player2.GetComponent<PlayerAttack>();

        player1Animation = player1.GetComponent<PlayerAnimationPlayer>();
        player2Animation = player2.GetComponent<PlayerAnimationPlayer>();
    }
    private void Start()
    {
        input.EnablePlayerInput();
    }
    private void Update()
    {
        Movement();
        Attack();
        Animation();
    }
    private void Movement()
    {
        player1Movement.Move(input.Player1Axes);
        player2Movement.Move(input.Player2Axes);

        if (input.Player1Jump) player1Movement.Jump();
        if (input.Player2Jump) player2Movement.Jump();
    }
    private void Attack()
    {
        if (player1Attack.isFinishAttack && player1EnemyDectector.isTrigger) player1Attack.Attack();
        if (player2Attack.isFinishAttack && player2EnemyDectector.isTrigger) player2Attack.Attack();
    }

    private void Animation()
    {
        if (player1Movement.isJumping) player1Animation.PlayJumpAnimation();
        else if (!player1Movement.isGround) player1Animation.PlayFallAnimation();
        else if (player1Movement.isMoving) player1Animation.PlayRunAnimation();
        else if (player1Attack.isAttacking) player1Animation.PlayAttackAnimation();
        else player1Animation.PlayIdleAnimation();

        if (player2Movement.isJumping) player2Animation.PlayJumpAnimation();
        else if (!player2Movement.isGround) player2Animation.PlayFallAnimation();
        else if (player2Movement.isMoving) player2Animation.PlayRunAnimation();
        else if (player2Attack.isAttacking) player2Animation.PlayAttackAnimation(); 
        else player2Animation.PlayIdleAnimation();
    }
    private void OnGUI()
    {
        if (showDebug)
        {
            Rect rect = new Rect(200, 150, 200, 200);

            string message = "isAttacking : " + player1Attack.isAttacking + "\n";

            GUIStyle style = new GUIStyle();
            style.fontSize = 50;
            style.fontStyle = FontStyle.Bold;
            style.normal.textColor = Color.white;

            GUI.Label(rect, message, style);

        }
    }
}
