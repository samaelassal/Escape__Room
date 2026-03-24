using UnityEngine;

public class Score : MonoBehaviour
{

    [SerializeField] private int score;
    [SerializeField] private int FinalScore;
    [SerializeField] private UnityEngine.Events.UnityEvent winAction;

    public void UpdateScore()
    {
        score ++;
        if(score == FinalScore)
        {
            winAction.Invoke();
        }
    
                
            
    }
}
