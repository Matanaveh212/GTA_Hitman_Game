using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float sightDistance;
    [SerializeField] private float sightAngle;

    bool isHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Projectile" || collision.transform.tag == "Car" && !isHit)
        {
            isHit = true;

            GetComponent<Animator>().enabled = false;
            GetComponent<SplineAnimate>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;

            transform.Find("Canvas").gameObject.SetActive(false);
            transform.Find("Root").gameObject.SetActive(true);

            FindObjectOfType<TargetsEliminated>().AddTargetScore();
        }
    }

    private void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (distanceToPlayer <= sightDistance && angleToPlayer <= sightAngle && !isHit)
        {
            Debug.Log("Spotted!");
        }

        /* Draw the distance to the player using a gizmo.
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + directionToPlayer * distanceToPlayer);

        // Draw the angle to the player using a gizmo.
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, angleToPlayer, 0) * transform.forward);
        */
    }
}
