using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class RelicPuzzle : MonoBehaviour
{
    [Header("Doors")]
    public GameObject entryDoor;   // drag EntryDoor here
    public GameObject exitDoor;    // drag ExitDoor here

    [Header("Socket")]
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor relicSocket; // drag RelicSocket here

    [Header("Audio")]
    public AudioClip doorLockSound;
    public AudioClip doorOpenSound;
    public AudioClip puzzleSolveSound;

    private AudioSource audioSource;
    private bool puzzleSolved = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Exit door starts closed — entry door will lock on trigger
        exitDoor.SetActive(true);

        // Listen for when something is placed in the socket
        relicSocket.selectEntered.AddListener(OnRelicPlaced);
    }

    // Called when player walks in — attach this to a trigger zone at the entrance
    public void LockEntryDoor()
    {
        entryDoor.SetActive(false); // wall appears, blocking exit
        if (doorLockSound) audioSource.PlayOneShot(doorLockSound);
        Debug.Log("Door locked!");
    }

    void OnRelicPlaced(SelectEnterEventArgs args)
    {
        if (puzzleSolved) return;
        puzzleSolved = true;

        if (puzzleSolveSound) audioSource.PlayOneShot(puzzleSolveSound);
        StartCoroutine(OpenExitDoor());
    }

    IEnumerator OpenExitDoor()
    {
        yield return new WaitForSeconds(1f); // short pause for drama
        if (doorOpenSound) audioSource.PlayOneShot(doorOpenSound);
        exitDoor.SetActive(false); // door disappears / opens
        Debug.Log("Puzzle solved! Exit open.");
    }
}