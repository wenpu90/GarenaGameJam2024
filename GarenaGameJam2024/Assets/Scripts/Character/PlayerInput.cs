using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerInput : MonoBehaviour
{
    [ShowInInspector]
    public PlayerInputActions playerInputActions;

    public float Player1Axes => playerInputActions.Player1.Axes.ReadValue<float>();
    public bool isPlayer1Moving => Player1Axes != 0f;
    public bool Player1Jump => playerInputActions.Player1.Jump.WasPressedThisFrame();
    public bool Player1Attack => playerInputActions.Player1.Attack.WasPressedThisFrame();

    public float Player2Axes => playerInputActions.Player2.Axes.ReadValue<float>();
    public bool isPlayer2Moving => Player2Axes != 0f;
    public bool Player2Jump => playerInputActions.Player2.Jump.WasPressedThisFrame();
    public bool Player2Attack => playerInputActions.Player2.Attack.WasPressedThisFrame();

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }
    public void EnablePlayerInput()
    {
        playerInputActions.Player1.Enable();
        playerInputActions.Player2.Enable();
    }
    public void DisablePlayerInput()
    {
        playerInputActions.Player1.Disable();
        playerInputActions.Player2.Disable();
    }
}
