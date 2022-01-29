using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [Header("Tweaks")]
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);

    private void Start()
    {
        GyroManager.Instance.EnableGyro();
    }

    private void Update()
    {
        transform.localRotation = GyroManager.Instance.GetGyroRotation() * baseRotation;
    }
}
