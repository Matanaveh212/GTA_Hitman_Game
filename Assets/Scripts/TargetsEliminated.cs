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
    public int countdown;
    public int targetsEliminated;
    public int totalTargets;

    private void Start()
    {
        if(countdownText) countdownText.text = countdown.ToString();
        currentTargetsText.text = targetsEliminated.ToString();
        totalTargetsText.text = totalTargets.ToString();
        StartCoroutine("Countdown");
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
        playerLoseText.text = "Challenge Completed!";
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<LevelLoader>().LoadThisScene(1);
    }

    IEnumerator PlayerLose(string loseMessage)
    {
        if (playerLoseText) playerLoseText.text = loseMessage;
        if (playerLoseText) playerLoseText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<LevelLoader>().LoadThisScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (countdownText) countdownText.text = countdown.ToString();
        if (countdown <= 0)
        {
            StartCoroutine("PlayerLose", "Time Is Up!");
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
