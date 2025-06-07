using UnityEngine;
using UnityEngine.Playables;


public class Opponent : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public float speed = 1.0f;
    private PlayerState opponentState;
    private bool isAttack = false;
    private float distance;
    private float chasingDistance = 3.5f;
    private float attackDistance = 2.0f;
    private bool isChasing;
    private bool isFinished;
    private Transform playerTransform;

    void Start()
    {
        opponentState = PlayerState.IDLE;
    }

    void Update()
    {
        HandleInput();

        PlayAnimation();
    }

    private void HandleInput1()
    {
        opponentState = PlayerState.IDLE;

        playerTransform = GameManager.Instance.GetPlayerTransform();
        distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance < chasingDistance)
        {
            opponentState = PlayerState.FORWARD;
        }
        if (distance < attackDistance)
        {
            opponentState = PlayerState.ATTACK;
        }
    }

    private void PlayAnimation()
    {
        switch (opponentState)
        {
            case PlayerState.IDLE:
                animator.Play("IDLE");
                break;
            case PlayerState.FORWARD:
                animator.Play("FORWARD");
                Vector3 direction = playerTransform.position - transform.position;
                direction = direction.normalized;
                transform.position += direction * speed * Time.deltaTime;
                break;
            case PlayerState.BACKWARD:
                animator.Play("BACKWARD");
                break;
            case PlayerState.ATTACK:
                {
                    animator.Play("ATTACK");
                    AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

                    if (animatorStateInfo.IsName("ATTACK") && animatorStateInfo.normalizedTime >= 1f)
                    {
                        isAttack = false;
                    }
                }
                break;
            default:
                break;
        }
    }



























    private void HandleInput()
    {
        if (!isAttack && !isChasing)
        {
            opponentState = PlayerState.IDLE;
        }

        playerTransform = GameManager.Instance.GetPlayerTransform();
        distance = Vector3.Distance(transform.position, playerTransform.position);
        Debug.Log("Player Position : " + playerTransform.position);

        if (distance > chasingDistance)
        {
            isChasing = false;
        }

        if (distance <= chasingDistance && distance >= attackDistance)
        {
            isChasing = true;
        }

        if (isChasing)
        {
            Vector3 direction = playerTransform.position - transform.position;
            direction = direction.normalized;
            transform.position += direction * speed * Time.deltaTime;
            opponentState = PlayerState.FORWARD;
        }

        if (distance <= attackDistance)
        {
            isChasing = false;
            isAttack = true;
            opponentState = PlayerState.ATTACK;
        }
    }


}