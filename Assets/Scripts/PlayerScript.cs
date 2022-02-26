using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public TMP_Text m_TimerText;

    [SerializeField]
    float walkSpeed = 5.0f;
    [SerializeField]
    float jumpForce = 15.0f;

    public float aimSensitivity = 1.0f;

    public readonly int movementXHash = Animator.StringToHash("MoveX");
    public readonly int movementYHash = Animator.StringToHash("MoveY");
    public readonly int isCrawlingHash = Animator.StringToHash("isCrawling");
    public readonly int isMovingHash = Animator.StringToHash("isMoving");
    public readonly int isJumpingHash = Animator.StringToHash("isJumping");

    private Vector2 inputVector = Vector2.zero;
    [SerializeField]
    private Vector3 moveDir = Vector3.zero;
    private Vector2 lookDir = Vector2.zero;

    private bool isJumping = false;
    private bool isCrawling = false;

    private Rigidbody playerRB;
    private Animator playerAnimator;

    public AudioSource WalkSFX;
    public AudioSource JumpSFX;

    public bool isGameOver = false;
    public bool playerWon = false;

    private float gameTimeLeft = 60.0f;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            UpdateSound();

            if (!(inputVector.magnitude > 0)) moveDir = Vector3.zero;

            moveDir = transform.forward * inputVector.y + transform.right * inputVector.x;
            Vector3 movementVec = moveDir * (walkSpeed * Time.deltaTime);
            transform.position += movementVec;

            gameTimeLeft -= Time.deltaTime;
            m_TimerText.text = "Time Left: " + (int)gameTimeLeft + "s";

            if (gameTimeLeft < 0.0f)
            {
                isGameOver = true;
                playerWon = false;
            }
        }
    }

    void UpdateSound()
    {
        if (inputVector.magnitude > 0)
        {
            if (!WalkSFX.isPlaying)
            {
                WalkSFX.Play();
            }
        }
        else
        {
            if (WalkSFX.isPlaying)
            {
                WalkSFX.Stop();
            }
        }
    }

    public void OnMovementAction(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        playerAnimator.SetBool(isMovingHash, (inputVector.magnitude > 0) ? true : false);

        playerAnimator.SetFloat("Blend", inputVector.x + 0.25f);
    }

    public void OnLook(InputValue value)
    {
        lookDir = value.Get<Vector2>();
        //Animation adjustment for aim direction
    }

    public void OnCrouch(InputValue value)
    {
        isCrawling = value.isPressed;
        playerAnimator.SetBool(isCrawlingHash, isCrawling);
    }

    public void OnJump(InputValue value)
    {
        if (!isJumping)
        {
            playerRB.AddForce((transform.up + moveDir) * jumpForce, ForceMode.Impulse);
            isJumping = value.isPressed;
            playerAnimator.SetBool(isJumpingHash, isJumping);
            JumpSFX.Play();
        }
    }

    public void SetLanded()
    {
        isJumping = false;
        playerAnimator.SetBool(isJumpingHash, isJumping);
    }
}
