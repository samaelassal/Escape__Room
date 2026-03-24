using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{

    [SerializeField] private int score;
    [SerializeField] private int FinalScore;
    [SerializeField] private UnityEvent winAction;


    public void UpdateScore()
    {
        score++;
        if(score == FinalScore)
        {
            winAction.Invoke();
        }
    }
}
