using UnityEngine;

public class EntranceTrigger : MonoBehaviour
{
    public RelicPuzzle puzzle; // drag the _PuzzleManager here

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (other.CompareTag("MainCamera") || other.CompareTag("Player"))
        {
            triggered = true;
            puzzle.LockEntryDoor();
        }
    }
}