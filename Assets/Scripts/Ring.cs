using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] Material collectedMaterial;
    [SerializeField] AudioClip ringCollected;
    bool isCollected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Car" && !isCollected)
        {
            GetComponent<Renderer>().material = collectedMaterial;
            FindAnyObjectByType<TargetsEliminated>().AddTargetScore();
            FindAnyObjectByType<SoundPlayer>().PlaySound(ringCollected);
            isCollected = true;
        }
    }
}
