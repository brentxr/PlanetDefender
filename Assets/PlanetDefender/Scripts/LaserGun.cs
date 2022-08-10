using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class LaserGun : MonoBehaviour
{

    [SerializeField] private Animator laserAnimator;
    [SerializeField] private AudioClip laserSFX;
    [SerializeField] private Transform raycastOrigin;

    private AudioSource laserAudioSource;
    private RaycastHit hit;

    private void Awake()
    {
        laserAudioSource = GetComponent<AudioSource>();
    }

    public void LaserGunFired()
    {
        laserAnimator.SetTrigger("Fire");
        
        laserAudioSource.PlayOneShot(laserSFX);
        
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, 800.0f))
        {
            if (hit.transform.GetComponent<AsteroidHit>() != null)
                hit.transform.GetComponent<AsteroidHit>().AsteroidDestroyed();
        }
        else if (hit.transform.GetComponent<IRaycastInterface>() != null)
        {
            hit.transform.GetComponent<IRaycastInterface>().HitByRaycast();
        }
    }
}
