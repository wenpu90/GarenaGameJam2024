using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerInput input;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    PlayerMovement player1Movement;
    PlayerMovement player2Movement;

    PlayerAttack player1Attack;
    PlayerAttack player2Attack;
    private void Awake()
    {
        player1Movement = player1.GetComponent<PlayerMovement>();
        player2Movement = player2.GetComponent<PlayerMovement>();

        player1Attack = player1.GetComponent<PlayerAttack>();
        player2Attack = player2.GetComponent<PlayerAttack>();
    }
    private void Start()
    {
        input.EnablePlayerInput();
    }
    private void Update()
    {
        player1Movement.Move(input.Player1Axes);
        player2Movement.Move(input.Player2Axes);

        if (input.Player1Jump) player1Movement.Jump();
        if (input.Player2Jump) player2Movement.Jump();

        if (player1Attack.isFinishAttack) player1Attack.Attack();
        if (player2Attack.isFinishAttack) player2Attack.Attack();
    }
}
