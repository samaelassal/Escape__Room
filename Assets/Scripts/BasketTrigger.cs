using UnityEngine;

public class BasketTrigger : MonoBehaviour
{
    public int ballsNeeded = 2;
    private int currentBalls = 0;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            currentBalls++;

            Debug.Log("Ball entered! Count: " + currentBalls);

            if (currentBalls == ballsNeeded)
            {
                PlayClap();
            }
        }
    }

    void PlayClap()
    {
        audioSource.Play();
        Debug.Log("🎉 Puzzle Completed!");
    }
}