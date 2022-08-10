using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticFeedback : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable grabInteractable;

    private void OnEnable()
    {
        grabInteractable.activated.AddListener(SendHapticFeedback);
    }

    private void SendHapticFeedback(ActivateEventArgs arg0)
    {
        arg0.interactorObject.transform.GetComponent<XRBaseController>().SendHapticImpulse(1f, .2f);
    }
}
