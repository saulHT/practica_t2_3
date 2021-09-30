using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public Text liveText;

    private int score = 0;
    public int live = 3;

    void Start()
    {
        ScoreText.text = "Score: " + score;
        PrintLifes();
    }

    // Update is called once per frame
    
    
        public int GetScore()
        {
            return this.score;
        }

        public void PlusScorte(int score)
        {
            this.score += score;
            ScoreText.text = "Score: " + score;
        }
        public void LoseLifes()
        {
            live -= 1;
            PrintLifes();
        }
        public int getLife()
        {
            return live;
        }

        public void PrintLifes()
        {
            var text = "Lives: ";
            for (var i = 0; i < live; i++)
            {
                text += "I";
            }
            liveText.text = text;
        }
    
}
