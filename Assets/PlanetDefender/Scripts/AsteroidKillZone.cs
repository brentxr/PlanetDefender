using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidKillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            other.GetComponent<Animator>().SetTrigger("FadeOut");
            Destroy(other.gameObject, 3f);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        var colSize = GetComponent<BoxCollider>().size;
        var localScale = gameObject.transform.localScale;
        Gizmos.DrawCube(transform.position, new Vector3(colSize.x * localScale.x, colSize.y * localScale.y, colSize.z * localScale.z));
    }
}
