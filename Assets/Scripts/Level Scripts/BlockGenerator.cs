﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockGenerator : MonoBehaviour
{
    public int NumberOfBlocks;
    public GameObject[] BlockPrefabs;
    public float TimeBetweenBlocks = 0;
    public int Seed = 0;
    private float timer = 0;
    List<GameObject> BlockList = new List<GameObject>();
    int counter = 0;
    private Vector3 spawnPoint;
    private System.Random randomNumberGenerator;
    private int randomBlock;
    private Player player;
    private GameObject lastBlock;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        randomNumberGenerator = new System.Random(Seed);
        randomBlock = GetRandomBlockNumber();
        lastBlock = player.gameObject;
        int randomPrefabType;
        for (int i = 0; i < NumberOfBlocks; i++)
        {
            randomPrefabType = randomNumberGenerator.Next(0, BlockPrefabs.Length);
            BlockList.Add(Instantiate(BlockPrefabs[randomPrefabType]));
            BlockList[i].GetComponent<Block>().SetIsActive(false);
        }
        timer = TimeBetweenBlocks;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            SpawnBlock();
            timer = TimeBetweenBlocks;
        }
        timer = timer - Time.deltaTime;
    }

    private void SpawnBlock()
    {
        int randomSpawnPosistion = randomNumberGenerator.Next(-10, 10);
        randomBlock = GetRandomBlockNumber();
        if (BlockList[randomBlock].GetComponent<Block>().GetIsActive() == false)
        {
            BlockList[randomBlock].GetComponent<Block>().SetIsActive(true);
            spawnPoint = new Vector3(randomSpawnPosistion, lastBlock.transform.position.y + 6, 0);
            BlockList[randomBlock].transform.position = spawnPoint;
            counter = 0;
            lastBlock = BlockList[randomBlock];
        }
    }

    private int GetRandomBlockNumber()
    {
        return randomNumberGenerator.Next(0, NumberOfBlocks);
    }

    public void OnEventOccurred(EventManager.EventTypes eventType)
    {
        if (eventType == EventManager.EventTypes.RestartGame)
        {
            foreach (GameObject block in BlockList)
            {
                block.SetActive(false);
            }
            lastBlock = player.gameObject;
        }
    }
}
