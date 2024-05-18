using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] bool showDebug;
    [SerializeField] PlayerInput input;
    [SerializeField] GameObject player1GameObject;
    [SerializeField] GameObject player2GameObject;

    [SerializeField] EnemyDetector player1EnemyDectector;
    [SerializeField] EnemyDetector player2EnemyDectector;

    Player player1;
    Player player2;

    PlayerMovement player1Movement;
    PlayerMovement player2Movement;

    PlayerAttack player1Attack;
    PlayerAttack player2Attack;

    PlayerAnimationPlayer player1Animation;
    PlayerAnimationPlayer player2Animation;
    private void Awake()
    {
        player1Movement = player1GameObject.GetComponent<PlayerMovement>();
        player2Movement = player2GameObject.GetComponent<PlayerMovement>();

        player1Attack = player1GameObject.GetComponent<PlayerAttack>();
        player2Attack = player2GameObject.GetComponent<PlayerAttack>();

        player1Animation = player1GameObject.GetComponent<PlayerAnimationPlayer>();
        player2Animation = player2GameObject.GetComponent<PlayerAnimationPlayer>();

        player1 = player1GameObject.GetComponent<Player>();
        player2 = player2GameObject.GetComponent<Player>();
    }
    private void Start()
    {
        input.EnablePlayerInput();
    }
    private void Update()
    {
        if (!player1.isDead)
        {
            Player1Movement();
            Player1Attack();
        }
        if (player1.isDead) player1Movement.Move(0);
        Player1Animation();

        if (!player2.isDead)
        {
            Player2Movement();
            Player2Attack();
        }
        if (player2.isDead) player2Movement.Move(0);
        Player2Animation();
    }
    private void Player1Movement()
    {
        player1Movement.Move(input.Player1Axes);
        if (input.Player1Jump) player1Movement.Jump();
    }
    private void Player2Movement()
    {
        player2Movement.Move(input.Player2Axes);
        if (input.Player2Jump) player2Movement.Jump();
    }
    private void Player1Attack()
    {
        if (!player1Movement.isJumping && !player1Movement.isMoving)
            if (player1Attack.isFinishAttack && player1EnemyDectector.isTrigger) player1Attack.Attack();
    }
    private void Player2Attack()
    {
        if (!player2Movement.isJumping && !player2Movement.isMoving)
            if (player2Attack.isFinishAttack && player2EnemyDectector.isTrigger) player2Attack.Attack();
    }
    private void Player1Animation()
    {
        if (player1.isDead) player1Animation.PlayDieAnimation();
        else if (player1Movement.isJumping) player1Animation.PlayJumpAnimation();
        else if (!player1Movement.isGround) player1Animation.PlayFallAnimation();
        else if (player1Movement.isMoving) player1Animation.PlayRunAnimation();
        else if (player1Attack.isAttacking && !player1Attack.isFinishAttack) player1Animation.PlayAttackAnimation();
        else player1Animation.PlayIdleAnimation();
    }
    private void Player2Animation()
    {
        if (player2.isDead) player2Animation.PlayDieAnimation();
        else if (player2Movement.isJumping) player2Animation.PlayJumpAnimation();
        else if (!player2Movement.isGround) player2Animation.PlayFallAnimation();
        else if (player2Movement.isMoving) player2Animation.PlayRunAnimation();
        else if (player2Attack.isAttacking && !player2Attack.isFinishAttack) player2Animation.PlayAttackAnimation(); 
        else player2Animation.PlayIdleAnimation();
    }
    private void OnGUI()
    {
        if (showDebug)
        {
            Rect rect = new Rect(200, 150, 200, 200);

            string message = "isAttacking : " + player1Attack.isAttacking + "\n" +
                             "isFinishAttack : " + player1Attack.isFinishAttack + "\n";


            GUIStyle style = new GUIStyle();
            style.fontSize = 50;
            style.fontStyle = FontStyle.Bold;
            style.normal.textColor = Color.white;

            GUI.Label(rect, message, style);

        }
    }
}
