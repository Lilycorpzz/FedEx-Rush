using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton instance

    public int totalPoints { get; private set; } = 0; // Player’s total points
    public TMP_Text Score;

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist GameManager across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager instances
        }
    }

    // Method to add points
    public void AddPoints(int points)
    {
        totalPoints += points;
        Debug.Log("Points added! Current Total: " + totalPoints);
        Score.text = "Score : " + totalPoints.ToString();
    }

    // Optional: Method to reset points (e.g., at the start of a new game or level)
    public void ResetPoints()
    {
        totalPoints = 0;
        Debug.Log("Points reset to zero.");
    }
}
