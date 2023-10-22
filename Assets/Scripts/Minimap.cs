using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public GameObject target;
    public bool rotation;

    private void LateUpdate()
    {
        Vector3 newPosition = target.transform.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        if (rotation) transform.rotation = Quaternion.Euler(90f, target.transform.eulerAngles.y, 0);
    }
}
