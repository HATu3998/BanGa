using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] TMP_Text textScore;
     private int score;
    public static ScoreController instance;
    private void Awake()
    {
        instance = this;
    }

 public   void GetScore(int scoren)
    {
        this.score += scoren;
        textScore.text = "Score : " + score.ToString();
    }
}
