using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    public InputActionReference attack;
    public Animator enemyAnimator;
    public Animator animator;
    private int attackCount = 0;
    void Start()
    {
    }

    void Update()
    {
        
    }

    public void AttackAction(InputAction.CallbackContext context)
{
    if (context.started) // срабатывает один раз при нажатии
    {
        attackCount++;
        if (attackCount <= 4)
        {
            animator.SetTrigger("IsAttacking");
            enemyAnimator.SetTrigger("isAttacked");
        }
        if (attackCount == 5 || attackCount == 6)
        {
            animator.SetTrigger("IsAttacking");
            enemyAnimator.SetTrigger("isDone");
        }
        if (attackCount >= 6)
        {
            animator.SetTrigger("IsTransforming");
            enemyAnimator.SetTrigger("isDone");
        }
    }
    // context.canceled больше не нужен — триггер сбрасывается сам
}
}
