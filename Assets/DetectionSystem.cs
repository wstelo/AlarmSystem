using UnityEngine;

[RequireComponent (typeof(BoxCollider))]
public class DetectionSystem : MonoBehaviour
{
    [SerializeField] private WarningSignal _warningSignal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Mover>(out _))
        {
            _warningSignal.EnableSignal();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Mover>(out _))
        {
            _warningSignal.DisableSignal();
        }
    }
}
