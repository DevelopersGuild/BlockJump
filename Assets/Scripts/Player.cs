using UnityEngine;
using System.Collections;

public class Player: MonoBehaviour
{
     public bool IsMobileControls;
     public float Speed = 1;
     public float JumpHeight = 1;
     public int ConsecutiveJumpsAllowed;

     private Vector3 movementDirection;
     private Rigidbody2D playerRigidBody;
     private int jumpCounter;
     int min = -13;
     int max = 13;

     void Start()
     {
          playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
          jumpCounter = 0;
     }
     void Update()
     {
          if(IsMobileControls == true)
          {
               MobileMovement();
          }
          else
          {
               KeyBoardMovement();
          }
     }

     public void MobileMovement()
     {
          movementDirection = new Vector3(Input.acceleration.x, 0f, 0f);
          if(movementDirection.sqrMagnitude > 1)
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
          if(Input.GetButtonDown("Jump"))
          {
               JumpPlayer();
          }
          MovePlayer();
     }

     private void MovePlayer()
     {

          transform.Translate(movementDirection * Time.deltaTime);
          if(transform.position.x > max)
          {
               transform.position = new Vector3(max, transform.position.y, 0);
          }
          if(transform.position.x < min)
          {
               transform.position = new Vector3(min, transform.position.y, 0);
          }
     }

     private void JumpPlayer()
     {
          if(jumpCounter < ConsecutiveJumpsAllowed)
          {
               playerRigidBody.AddForce(new Vector2(0f, JumpHeight));
               jumpCounter++;
          }
     }

     public void OnCollisionEnter2D(Collision2D collision)
     {
          if (collision.gameObject.tag == "Platform")
          {
               ResetJumpCounter();
          }
     }

     private void ResetJumpCounter()
     {
          jumpCounter = 0;
     }
}