using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeKillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
