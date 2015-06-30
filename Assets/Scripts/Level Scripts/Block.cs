using UnityEngine;
using System.Collections;


public class Block : MonoBehaviour
{
     public bool IsActive;
     public int MinSpeed;
     public int MaxSpeed;
     private float speed;
     private Vector3 movementDirection;
     private System.Random randomNumberGenerator;

     void Start()
     {
          randomNumberGenerator = new System.Random();
          speed = randomNumberGenerator.Next(MinSpeed, MaxSpeed);
     }

     void Update()
     {
          movementDirection = new Vector3(0, -speed, 0);
          transform.Translate(movementDirection * Time.deltaTime);
     }

     public void SetIsActive(bool value)
     {
          IsActive = value;
          gameObject.SetActive(value);
     }

     public bool GetIsActive()
     {
          return IsActive;
     }

     public void OnTriggerEnter2D(Collider2D collider)
     {
          if(collider.tag == "Platform")
          {
               this.SetIsActive(false);
          }
     }
}
