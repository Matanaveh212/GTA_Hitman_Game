using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetsEliminated : MonoBehaviour
{
    public TMP_Text currentTargetsText;
    public TMP_Text totalTargetsText;
    public int targetsEliminated;
    public int totalTargets;

    private void Start()
    {
        currentTargetsText.text = targetsEliminated.ToString();
        totalTargetsText.text = totalTargets.ToString();
    }

    public void AddTargetScore()
    {
        targetsEliminated++;
        currentTargetsText.text = targetsEliminated.ToString();

        if(targetsEliminated == totalTargets)
        {
            Debug.Log("All targets are Eliminated!");
        }
    }
}
