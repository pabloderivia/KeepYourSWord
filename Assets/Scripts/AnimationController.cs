using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    public bool IsAttacking = false;
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMoveSpeed(float speed)
    {
        animator.SetFloat("MoveSpeed", speed);
    }
    public void SetTriggerAttack( bool applyRootMotion = false )
    {
        IsAttacking = true;
        animator.SetTrigger("Attack");
        animator.applyRootMotion = applyRootMotion;

    }

    public void SetIsAttackingOff()
    {
        IsAttacking = false;

    }

    public bool GetIsAttacking()
    {
        return animator.GetBool("IsAttacking");
    }
    
    public void ResetAttackTrigger()
    {
        animator.ResetTrigger("Attack");
      
    }
}
