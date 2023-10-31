using UnityEngine;

public class FollowCar : MonoBehaviour
{
    GameObject car;
    void Update()
    {
        car = FindAnyObjectByType<CarEnterExit>().gameObject;
        transform.position = car.transform.position + new Vector3(3, 0, 0);
    }
}