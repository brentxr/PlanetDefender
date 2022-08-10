using UnityEngine;
using UnityEngine.Events;


public class UserInterfaceInteraction : MonoBehaviour, IRaycastInterface
{

    public UnityEvent onHitByRaycast;
    
    public void HitByRaycast()
    {
        onHitByRaycast.Invoke();
    }
}
