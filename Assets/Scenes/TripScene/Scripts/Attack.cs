using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    public InputActionReference attack;
    public Animator enemyAnimator;
    public Animator animator;
    public List<GameObject> finalSceneObjects;
    private int attackCount = 0;
    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    public void AttackAction(InputAction.CallbackContext context)
{
    if (context.started)
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
        if (attackCount > 9)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                animator.SetBool("IsEnd", true);
                enemyAnimator.SetBool("isLooping", true);
                foreach (GameObject obj in finalSceneObjects)
                {
                    obj.SetActive(true);
                }
            }
    }
}
}
