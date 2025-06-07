using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{
    IDLE, FORWARD, BACKWARD, ATTACK
}

public class Player : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public float speed = 1.0f;

    private PlayerState playerState;

    private Transform playerTransform;

    private bool isMoving;

    private bool isAttack;

    public Transform GetTransform()
    {
        return playerTransform;
    }
    void Start()
    {
        playerState = PlayerState.IDLE;
    }
    void Update()
    {
        playerTransform = transform;

        HandleInput();

        PlayAnimation();
    }
    private void HandleInput()
    {
        if (playerState != PlayerState.ATTACK)
        {
            playerState = PlayerState.IDLE;

            if (Input.GetKey(KeyCode.A))
            {
                playerState = PlayerState.BACKWARD;
            }
            if (Input.GetKey(KeyCode.D))
            {
                playerState = PlayerState.FORWARD;
            }
            if (Input.GetMouseButtonDown(0))
            {
                isAttack = true;
                playerState = PlayerState.ATTACK;
            }
        }
    }


    private void PlayAnimation()
    {
        switch (playerState)
        {
            case PlayerState.IDLE:
                animator.Play("IDLE");
                break;
            case PlayerState.FORWARD:
                {
                    transform.position += Vector3.right * Time.deltaTime * speed;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    animator.Play("FORWARD");
                    playerState = PlayerState.IDLE;
                }
                break;
            case PlayerState.BACKWARD:
                {
                    transform.position += Vector3.left * Time.deltaTime * speed;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    animator.Play("BACKWARD");
                    playerState = PlayerState.IDLE;
                }
                break;
            case PlayerState.ATTACK:
                {
                    animator.Play("ATTACK");
                    AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

                    if (animatorStateInfo.IsName("ATTACK") && animatorStateInfo.normalizedTime >= 1f)
                    {
                        playerState = PlayerState.IDLE;
                    }
                }
                break;
            default:
                break;
        }
    }


}