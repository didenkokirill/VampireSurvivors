using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] private int score;
    [SerializeField] private int bestScore;
    [SerializeField] private TMP_Text scoreText, bestScoreText;
    private TMP_Text scoreTextBase, bestScoreTextBase;

    private void Start()
    {
        scoreTextBase = scoreText;
        bestScoreTextBase = bestScoreText;
    }

    private void Awake() => Instance = this;

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void ChangeBestScore()
    {
        if (score > bestScore)
        {
            bestScore = score;
        }
    }
    public void UpdateScoresTexts()
    {
        scoreText.text = scoreTextBase.text + score.ToString();
        bestScoreText.text = bestScoreTextBase.text + bestScore.ToString();
    }
}
