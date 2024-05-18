using UnityEngine;

public class PlayerAnimationPlayer : MonoBehaviour
{
    [SerializeField] Animator animator;
    public void PlayIdleAnimation()
    {
        animator.Play("Idle");
    }
    public void PlayRunAnimation()
    {
        animator.Play("Run");
    }
    public void PlayJumpAnimation()
    {
        animator.Play("Jump");
    }
    public void PlayFallAnimation()
    {
        animator.Play("Fall");
    }
    public void PlayAttackAnimation()
    {
        animator.Play("Attack");
    }
    public void PlayDieAnimation()
    {
        animator.Play("Die");
    }
}
