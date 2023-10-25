using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float sightDistance;
    [SerializeField] private float sightAngle;
    [SerializeField] AudioClip death;

    bool isHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Projectile" || collision.transform.tag == "Car" && !isHit)
        {
            EnemyDeath();
        }
    }

    public void EnemyDeath()
    {
        isHit = true;

        GetComponent<Animator>().enabled = false;
        if (GetComponent<SplineAnimate>()) GetComponent<SplineAnimate>().enabled = false;
        GetComponent<Collider>().enabled = false;

        transform.Find("Canvas").gameObject.SetActive(false);
        transform.Find("Root").gameObject.SetActive(true);

        FindObjectOfType<TargetsEliminated>().AddTargetScore();
        FindAnyObjectByType<SoundPlayer>().PlaySound(death);
    }

    private void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (distanceToPlayer <= sightDistance && angleToPlayer <= sightAngle && !isHit)
        {
            FindAnyObjectByType<TargetsEliminated>().StartCoroutine("PlayerLose", "They Spotted You!");
        }
    }

    private void OnDrawGizmos()
    {
        float distance = Vector3.Distance(transform.position, Camera.current.transform.position);
        Vector3 forward = transform.forward;

        Vector3 point2 = transform.position + Quaternion.Euler(0, sightAngle / 2f, 0) * forward * sightDistance;
        Vector3 point3 = transform.position + Quaternion.Euler(0, -sightAngle / 2f, 0) * forward * sightDistance;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, point2);
        Gizmos.DrawLine(transform.position, point3);
        Gizmos.DrawLine(point2, point3);
    }
}
