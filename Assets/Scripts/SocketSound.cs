using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketSound : MonoBehaviour
{
    public AudioSource audioSource;

    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;

    void Start()
    {
        socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();

        if (socket != null)
        {
            socket.selectEntered.AddListener(OnObjectPlaced);
        }
    }

    private void OnObjectPlaced(SelectEnterEventArgs args)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    private void OnDestroy()
    {
        if (socket != null)
        {
            socket.selectEntered.RemoveListener(OnObjectPlaced);
        }
    }
}