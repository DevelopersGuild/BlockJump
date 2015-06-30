using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockGenerator : MonoBehaviour
{
     public int NumberOfBlocks;
     public GameObject BlockPrefab;
     List<GameObject> BlockList = new List<GameObject>();
     int counter = 0;
     private Vector3 spawnPoint;
     private System.Random randomNumberGenerator;
     private int randomBlock;
     private Player player;
     // Use this for initialization
     void Start()
     {
          player = FindObjectOfType<Player>();
          randomNumberGenerator = new System.Random();
          randomBlock = GetRandomBlockNumber();
          spawnPoint = new Vector3(0, player.transform.position.y + 30, 0);
          for (int i = 0; i < NumberOfBlocks; i++)
          {
               BlockList.Add(Instantiate(BlockPrefab));
               BlockList[i].GetComponent<Block>().SetIsActive(false);
          }

     }

     // Update is called once per frame
     void Update()
     {
          if (counter < 100)
          {
               counter++;
          }
          else
          {
               int randomSpawnPosistion = randomNumberGenerator.Next(-10, 10);
               randomBlock = GetRandomBlockNumber();
               if (BlockList[randomBlock].GetComponent<Block>().GetIsActive() == false)
               {
                    BlockList[randomBlock].GetComponent<Block>().SetIsActive(true);
                    spawnPoint.x = randomSpawnPosistion;
                    BlockList[randomBlock].transform.position = spawnPoint;
                    counter = 0;
               }
          }

     }

     private int GetRandomBlockNumber()
     {
          return randomNumberGenerator.Next(0, NumberOfBlocks);
     }
}
