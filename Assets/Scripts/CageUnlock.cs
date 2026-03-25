using UnityEngine;

public class CageUnlock : MonoBehaviour
{
    public GameObject correctKey;
    public Transform leftDoor;
    public Transform rightDoor;
    public GameObject successMessage;
    public AudioSource unlockSound;
    public AudioSource doorOpenSound;

    private bool unlocked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (unlocked) return;

        if (other.gameObject == correctKey)
        {
            Rigidbody rb = correctKey.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }

            correctKey.transform.position = transform.position;

            UnlockCage();
        }
    }

    void UnlockCage()
    {
        unlocked = true;

        if (unlockSound != null)
            unlockSound.Play();

        if (doorOpenSound != null)
            doorOpenSound.Play();

        if (correctKey != null)
            correctKey.SetActive(false);

        if (leftDoor != null)
            leftDoor.Rotate(0f, -90f, 0f);

        if (rightDoor != null)
            rightDoor.Rotate(0f, 90f, 0f);

        if (successMessage != null)
            successMessage.SetActive(true);

        Debug.Log("Cage unlocked!");
    }
}