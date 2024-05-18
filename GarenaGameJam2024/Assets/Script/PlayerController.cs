using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerInput input;
    [SerializeField] PlayerMovement player1Movement;
    [SerializeField] PlayerMovement player2Movement;
    private void Awake()
    {
        input.EnablePlayerInput();
    }
    private void Update()
    {
        player1Movement.Move(input.Player1Axes);
        player2Movement.Move(input.Player2Axes);

        if (input.Player1Jump) player1Movement.Jump();
        if (input.Player2Jump) player2Movement.Jump();
    }
}
