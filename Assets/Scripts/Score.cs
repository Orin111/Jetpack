using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (scoreText != null) // Check if scoreText is assigned
        {
            scoreText.text = "Score: " + Game.score;
        }
        else
        {
            Debug.LogWarning("Score TextMeshProUGUI not assigned in the Inspector.");
        }
    }
}