using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetsEliminated : MonoBehaviour
{
    public TMP_Text currentTargetsText;
    public TMP_Text totalTargetsText;
    public TMP_Text playerLoseText;
    public TMP_Text countdownText;
    public AudioClip lost;
    public AudioClip completed;
    public int countdown;
    public int targetsEliminated;
    public int totalTargets;
    bool isLose;
    bool isCompleted;

    private void Start()
    {
        if(countdownText) countdownText.text = countdown.ToString();
        currentTargetsText.text = targetsEliminated.ToString();
        totalTargetsText.text = totalTargets.ToString();
        if (SceneManager.GetActiveScene().buildIndex != 2) StartCoroutine("Countdown");
    }

    public void AddTargetScore()
    {
        targetsEliminated++;
        currentTargetsText.text = targetsEliminated.ToString();

        if (targetsEliminated == totalTargets)
        {
            StartCoroutine("LoadChallenges");
        }
    }

    IEnumerator LoadChallenges()
    {
        if(!isCompleted)
        {
            isCompleted = true;
            GetComponent<AudioSource>().clip = completed;
            GetComponent<AudioSource>().Play();
            playerLoseText.text = "Challenge Completed!";
            if(GameObject.FindGameObjectWithTag("PlayerCanvas")) GameObject.FindGameObjectWithTag("PlayerCanvas").SetActive(false);
            yield return new WaitForSeconds(1.5f);
            FindObjectOfType<LevelLoader>().LoadThisScene(1);
        }
    }

    IEnumerator PlayerLose(string loseMessage)
    {
        if(!isLose)
        {
            isLose = true;
            GetComponent<AudioSource>().clip = lost;
            GetComponent<AudioSource>().Play(); 
            if (playerLoseText) playerLoseText.text = loseMessage;
            if (playerLoseText) playerLoseText.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            FindObjectOfType<LevelLoader>().LoadThisScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Update()
    {
        if (countdownText && SceneManager.GetActiveScene().buildIndex != 2)
        {
            countdownText.text = countdown.ToString();

            if (countdown <= 0)
            {
                StartCoroutine("PlayerLose", "Time Is Up!");
            }
        }
    }

    IEnumerator Countdown()
    {
        while (countdown > 0)
        {
            yield return new WaitForSeconds(1f);
            countdown--;
        }
    }
}
