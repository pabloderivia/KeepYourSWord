using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
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
    public void SetIsAttacking(bool isAttacking)
    {
        animator.SetBool("IsAttacking", isAttacking);

    }

    public void SetIsAttackingOff()
    {
        animator.SetBool("IsAttacking", false);

    }
    
    public bool GetIsAttacking()
    {
        return animator.GetBool("IsAttacking");
    }
}
