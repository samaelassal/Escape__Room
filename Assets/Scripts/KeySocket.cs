using UnityEngine;


public class CageUnlockSocket : MonoBehaviour
{
    public GameObject correctKey;
    public Transform leftDoor;
    public Transform rightDoor;
    public GameObject successMessage;
    public AudioSource unlockSound;
    public AudioSource doorOpenSound;

    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;
    private bool unlocked = false;

    void Start()
    {
        socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
    }

    void Update()
    {
        if (unlocked || socket == null) return;

        if (socket.hasSelection && socket.interactablesSelected.Count > 0)
        {
            GameObject insertedObject = socket.interactablesSelected[0].transform.gameObject;

            if (insertedObject == correctKey)
            {
                UnlockCage();
            }
        }
    }

    void UnlockCage()
    {
        unlocked = true;

        if (unlockSound != null)
            unlockSound.Play();

        if (doorOpenSound != null)
            doorOpenSound.Play();

        UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab = correctKey.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grab != null)
            grab.enabled = false;

        Rigidbody rb = correctKey.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        if (leftDoor != null)
            leftDoor.Rotate(0f, -90f, 0f);

        if (rightDoor != null)
            rightDoor.Rotate(0f, 90f, 0f);

        if (successMessage != null)
            successMessage.SetActive(true);

        Debug.Log("Cage unlocked!");
    }
}