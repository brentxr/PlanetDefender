using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ReturnToOrigin : MonoBehaviour
{
    [SerializeField] private Pose originPose;

    private XRGrabInteractable _grabInteractable;

    private void Awake()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
        originPose.position = transform.position;
        originPose.rotation = transform.rotation;
    }

    private void OnEnable() => _grabInteractable.selectExited.AddListener(LaserGunReleased);

    private void OnDisable() => _grabInteractable.selectExited.RemoveListener(LaserGunReleased);

    private void LaserGunReleased(SelectExitEventArgs e)
    {
        transform.position = originPose.position;
        transform.rotation = originPose.rotation;
    }
}
