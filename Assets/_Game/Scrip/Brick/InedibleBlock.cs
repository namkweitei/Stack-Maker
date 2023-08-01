using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InedibleBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
