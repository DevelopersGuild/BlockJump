﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

     // Use this for initialization
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {

     }

     public void SwitchLevel(int LevelNumber)
     {
          Application.LoadLevel(LevelNumber);
     }

     public void ExitGame()
     {
          Application.Quit();
     }
}

