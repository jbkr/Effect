using UnityEngine;

public enum PlayerState
{
    IDLE, FORWARD, BACKWARD, ATTACK, HITTED
}

public class Player : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Opponent opponent;

    public float speed = 1.0f;
    private PlayerState playerState;

    void Start()
    {
        playerState = PlayerState.IDLE;
    }

    void Update()
    {
        HandleInput();
        PlayAnimation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other is BoxCollider)
        {
            Debug.Log("Hit");

            GameManager.Instance.OnPlayerHit();
        }


    }



    private void HandleInput()
    {
        if (playerState != PlayerState.ATTACK && playerState != PlayerState.HITTED)
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
                    //playerState = PlayerState.IDLE;
                }
                break;
            case PlayerState.BACKWARD:
                {
                    transform.position += Vector3.left * Time.deltaTime * speed;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    animator.Play("BACKWARD");
                    //playerState = PlayerState.IDLE;
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
            case PlayerState.HITTED:
                {
                    transform.position += Vector3.left * Time.deltaTime * speed * 1.5f;

                    animator.Play("HITTED");
                    AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

                    if (animatorStateInfo.IsName("HITTED") && animatorStateInfo.normalizedTime >= 1f)
                    {
                        playerState = PlayerState.IDLE;
                    }
                }
                break;
            default:
                break;
        }
    }
    public void SetState(PlayerState state)
    {
        this.playerState = state;
    }
}