using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    public bool isHit = false;
    public AudioClip downSound;
    public AnimationClip targetDown;
    public AudioSource audioSource;
    public Canvas canvas;
    bool hit;

    private void Update()
    {
        //If the target is hit
        if (isHit & !hit)
        {
            //Animate the target "down"
            gameObject.GetComponent<Animation>().clip = targetDown;
            gameObject.GetComponent<Animation>().Play();

            //Set the downSound as current sound, and play it
            audioSource.GetComponent<AudioSource>().clip = downSound;
            audioSource.Play();

            canvas.gameObject.SetActive(false);
            FindObjectOfType<TargetsEliminated>().AddTargetScore();

            hit = true;
        }
    }
}