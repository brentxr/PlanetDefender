using UnityEngine;


public class PopupControl : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(Camera.main?.transform);
        
        Destroy(gameObject, 3.0f);
    }
}