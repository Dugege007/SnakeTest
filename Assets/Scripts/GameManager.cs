using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeTest
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public Snake Snake;
        public bool IsGaming = true;

        public int Score = 0;

        protected override void Awake()
        {
            base.Awake();

            if (Snake == null)
                Snake = GameObject.FindGameObjectWithTag("Snake").GetComponent<Snake>();
        }

        public void GameOver()
        {
            //TODO
            IsGaming = false;
            Debug.Log("”Œœ∑Ω· ¯");
        }
    }
}
