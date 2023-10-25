using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "Car")
        {
            FindAnyObjectByType<LevelLoader>().LoadThisScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
