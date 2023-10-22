using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform pointC;
    [SerializeField] private Transform pointD;

    [SerializeField] private float Speed;

    private float interpolateAmount;

    private bool atPointB = false;
    private bool atPointC = false;
    private bool atPointD = false;

    private void Update()
    {
        interpolateAmount += Time.deltaTime % 1f * Speed;

        if (!atPointB)
        {
            transform.LookAt(pointB.position);
            transform.position = Vector3.Slerp(pointA.position, pointB.position, interpolateAmount);
            if (transform.position == pointB.position)
            {
                atPointB = true;
            }
        }
        else if (!atPointC)
        {
            transform.LookAt(pointC.position);
            transform.position = Vector3.Slerp(pointB.position, pointC.position, interpolateAmount);
            if (transform.position == pointC.position)
            {
                atPointC = true;
            }
        }
        else if (!atPointD)
        {
            transform.LookAt(pointD.position);
            transform.position = Vector3.Slerp(pointC.position, pointD.position, interpolateAmount);
            if (transform.position == pointD.position)
            {
                atPointD = true;
            }
        }
        else if (atPointD)
        {
            transform.LookAt(pointA.position);
            transform.position = Vector3.Slerp(pointD.position, pointA.position, interpolateAmount);
            if (transform.position == pointA.position)
            {
                atPointD = false;
            }
        }
    }
}
