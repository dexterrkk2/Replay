using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Cubethon.Command
{
    public class Score : MonoBehaviour
    {
        public Transform player;
        public Text scoreText;
        public GameManager gameManager;
        // Update is called once per frame
        void Update()
        {
            Data.instance.score = (Data.instance.timer * gameManager.difficulty*10);
            scoreText.text = Data.instance.score.ToString("0");
        }
    }
}
