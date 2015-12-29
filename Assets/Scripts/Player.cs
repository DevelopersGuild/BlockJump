using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public bool IsMobileControls;
    public float Speed = 1;
    public float JumpHeight = 1;
    public int ConsecutiveJumpsAllowed;

    private Vector3 movementDirection;
    private Rigidbody2D playerRigidBody;
    private int jumpCounter;
    private float varaibleSpeed;
    private bool isPlayerOffGround = false;
    private bool isPlayerDead = false;
    private Vector3 playerStartPosistion;
    private Animator playerAnimator;
    int min = -13;
    int max = 13;

    void Start()
    {
        varaibleSpeed = Speed;
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        jumpCounter = 0;
        playerStartPosistion = gameObject.transform.position;
        playerAnimator = gameObject.GetComponent<Animator>();
        GameManager.Events.AddEventListner(OnEventOccurred, EventManager.EventTypes.RestartGame);
    }
    void Update()
    {
        if (isPlayerDead == false)
        {
            if (IsMobileControls == true)
            {
                MobileMovement();
            }
            else
            {
                KeyBoardMovement();
            }
            if (isPlayerOffGround == false)
            {
                if (gameObject.transform.position.y > 4)
                {
                    GameManager.Events.CallEvent(EventManager.EventTypes.PlayerLeftGround);
                    isPlayerOffGround = true;
                }
            }
        }
    }

    public void MobileMovement()
    {
        movementDirection = new Vector3(Input.acceleration.x, 0f, 0f);
        if (movementDirection.sqrMagnitude > 1)
        {
            movementDirection.Normalize();
        }
        movementDirection *= (Speed * 5);
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                JumpPlayer();
            }
        }

        MovePlayer();
    }

    public void KeyBoardMovement()
    {
        movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        movementDirection *= Speed;
        if (Input.GetButtonDown("Jump"))
        {
            JumpPlayer();
        }
        MovePlayer();
    }

    private void MovePlayer()
    {

        transform.Translate(movementDirection * Time.deltaTime);
        if (transform.position.x > max)
        {
            transform.position = new Vector3(max, transform.position.y, 0);
        }
        if (transform.position.x < min)
        {
            transform.position = new Vector3(min, transform.position.y, 0);
        }
        if (movementDirection.x != 0)
        {
            FlipSprite(movementDirection.x >= 0 ? 1 : -1);
            playerAnimator.SetBool("IsMoving", true);
        }
        else
        {
            playerAnimator.SetBool("IsMoving", false);
        }
    }

    private void FlipSprite(int directionToFace)
    {
        transform.localScale = new Vector3(directionToFace, 1, 1);
    }

    private void JumpPlayer()
    {
        if (jumpCounter < ConsecutiveJumpsAllowed)
        {
            playerRigidBody.AddForce(new Vector2(0f, JumpHeight));
            playerAnimator.SetBool("IsJumping", true);
            jumpCounter++;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            ResetJumpCounter();
            Speed = Speed / 2;
            playerAnimator.SetBool("IsJumping", false);
        }
        if (collision.gameObject.tag == "Ground")
        {
            if (collision.gameObject.GetComponent<Ground>().GetDoesGroundKillPlayer() == true)
            {
                GameManager.Events.CallEvent(EventManager.EventTypes.PlayerDeath);
                isPlayerDead = true;
            }
            ResetJumpCounter();
            Speed = Speed / 2;
        }
    }

    public void OnEventOccurred(EventManager.EventTypes eventType)
    {
        if (eventType == EventManager.EventTypes.RestartGame)
        {
            SetIsPlayerDead(false);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        Speed = varaibleSpeed;
    }

    public void SetIsPlayerDead(bool value)
    {
        isPlayerDead = value;
    }

    private void ResetJumpCounter()
    {
        jumpCounter = 0;
    }
}