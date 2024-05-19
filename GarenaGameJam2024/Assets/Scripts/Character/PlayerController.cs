using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] bool showDebug;
    [SerializeField] PlayerInput input;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    Player p1;
    Player p2;

    [SerializeField] EnemyDetector player1EnemyDectector;
    [SerializeField] EnemyDetector player2EnemyDectector;

    public PlayerMovement player1Movement;
    public PlayerMovement player2Movement;

    PlayerAttack player1Attack;
    PlayerAttack player2Attack;

    PlayerAnimationPlayer player1Animation;
    PlayerAnimationPlayer player2Animation;

    public bool p1StopMovement;
    public bool p2StopMovement;
    public bool isDead;

    private void Awake()
    {
        player1Movement = player1.GetComponent<PlayerMovement>();
        player1Attack = player1.GetComponent<PlayerAttack>();
        player1Animation = player1.GetComponent<PlayerAnimationPlayer>();
        p1 = player1.GetComponent<Player>();

        player2Movement = player2.GetComponent<PlayerMovement>();
        player2Attack = player2.GetComponent<PlayerAttack>();
        player2Animation = player2.GetComponent<PlayerAnimationPlayer>();
        p2 = player2.GetComponent<Player>();
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

        if (!p1StopMovement && !p1.isDead)
        {
            player1Movement.Move(input.Player1Axes);
            if (input.Player1Jump) player1Movement.Jump();
        }
        else
        {
            player1Movement.Move(0);
        }
        if (!p2StopMovement && !p2.isDead)
        {
            player2Movement.Move(input.Player2Axes);
            if (input.Player2Jump) player2Movement.Jump();
        }
        else
        {
            player1Movement.Move(0);
        }
    }

    private void Attack()
    {
        if (!p1StopMovement && !p1.isDead)
        {
            if (!player1Movement.isJumping && !player1Movement.isMoving)
                if (player1Attack.isFinishAttack && player1EnemyDectector.isTrigger) player1Attack.Attack();
        }
        else
        {
            player1Attack.DisabledHitbox();
        }

        if (!p2StopMovement && !p2.isDead)
        {
            if (!player2Movement.isJumping && !player2Movement.isMoving)
                if (player2Attack.isFinishAttack && player2EnemyDectector.isTrigger) player2Attack.Attack();
        }
        else
        {
            player2Attack.DisabledHitbox();
        }

    }

    private void Animation()
    {
        if (!p1StopMovement)
        {
            if (p1.isDead) player1Animation.PlayDieAnimation();
            else if (player1Movement.isJumping) player1Animation.PlayJumpAnimation();
            else if (!player1Movement.isGround) player1Animation.PlayFallAnimation();
            else if (player1Movement.isMoving) player1Animation.PlayRunAnimation();
            else if (player1Attack.isAttacking && !player1Attack.isFinishAttack) player1Animation.PlayAttackAnimation();
            else player1Animation.PlayIdleAnimation();
        }

        if (!p2StopMovement)
        {
            if (p2.isDead) player2Animation.PlayDieAnimation();
            else if (player2Movement.isJumping) player2Animation.PlayJumpAnimation();
            else if (!player2Movement.isGround) player2Animation.PlayFallAnimation();
            else if (player2Movement.isMoving) player2Animation.PlayRunAnimation();
            else if (player2Attack.isAttacking && !player2Attack.isFinishAttack) player2Animation.PlayAttackAnimation();
            else player2Animation.PlayIdleAnimation();
        }

    }
    private void OnGUI()
    {
        return;
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
