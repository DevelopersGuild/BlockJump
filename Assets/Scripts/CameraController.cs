using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
     private Player player;
     private Vector3 playerPosition;
     // Use this for initialization
     void Start()
     {
          player = FindObjectOfType<Player>();
     }

     // Update is called once per frame
     void Update()
     {
          playerPosition = new Vector3(transform.position.x,player.transform.position.y + 5, transform.position.z);
          transform.position = playerPosition;
     }
}
