using System.Collections;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public float speed = 1.0f;
    private PlayerState opponentState;
    private float distance;
    private float chasingDistance = 2.5f;
    private float attackDistance = 1.5f;
    private Enemy1 player;

    public PlayerState GetOpponentState()
    {
        return opponentState;
    }

    //[SerializeField]
    //private Player player;

    void Start()
    {
        opponentState = PlayerState.IDLE;
        isAttackable = true;
    }

    void Update()
    {
        HandleInput();
        PlayAnimation();
    }

    private bool isAttackable;

    private void HandleInput()
    {
        if (opponentState != PlayerState.ATTACK)
        {
            opponentState = PlayerState.IDLE;

            if (isAttackable)
            {
                player = GameManager.Instance.GetPlayer();
                distance = Vector3.Distance(transform.position, player.transform.position);

                if (distance < chasingDistance)
                {
                    opponentState = PlayerState.FORWARD;
                }
                if (distance < attackDistance)
                {
                    opponentState = PlayerState.ATTACK;
                }
            }
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
                Vector3 direction = player.transform.position - transform.position;
                direction = direction.normalized;
                transform.position += direction * speed * Time.deltaTime;
                break;
            case PlayerState.BACKWARD:
                animator.Play("BACKWARD");
                transform.position += Vector3.right * Time.deltaTime * speed;
                transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                break;
            case PlayerState.ATTACK:
                {
                    animator.Play("ATTACK");
                    AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

                    if (animatorStateInfo.IsName("ATTACK") && animatorStateInfo.normalizedTime >= 0.5f)
                    {
                        player.SetState(PlayerState.HITTED);
                    }
                    if (animatorStateInfo.IsName("ATTACK") && animatorStateInfo.normalizedTime >= 1.0f)
                    {
                        player.SetIsHitted(false);
                        opponentState = PlayerState.IDLE;
                        isAttackable = false;
                        StartCoroutine(CoolTime());
                    }
                }
                break;
            default:
                break;
        }
    }

    private IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(3.0f);
        isAttackable = true;
    }
}