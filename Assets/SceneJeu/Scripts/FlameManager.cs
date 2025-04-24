using System.Collections.Generic;
using UnityEngine;

public class FlameManager : MonoBehaviour
{
    public GameObject[] goals;             // Tous les buts
    public GameObject currentGoal;         // Objectif actuel
    private GameObject lastGoal;           // Dernier but visité

    private void Start()
    {
        // Allumer tous les goals au début
        foreach (GameObject goal in goals)
        {
            goal.transform.Find("VFX_Fire").gameObject.SetActive(true);
        }

        ChooseNewGoal(null); // Premier goal, pas de précédent
    }

    public void GoalReached(GameObject reachedGoal)
    {
        // Éteindre la flamme de ce but
        reachedGoal.transform.Find("VFX_Fire").gameObject.SetActive(false);

        // Choisir un nouveau goal
        ChooseNewGoal(reachedGoal);
    }

    void ChooseNewGoal(GameObject justReached)
    {
        // Rallumer le goal précédent si nécessaire
        if (lastGoal != null && lastGoal != justReached)
        {
            lastGoal.transform.Find("VFX_Fire").gameObject.SetActive(true);
        }

        GameObject newGoal;
      
            do
            {
                newGoal = goals[Random.Range(0, goals.Length)];
            }
            while (newGoal == justReached && goals.Length > 1);

        currentGoal = newGoal;
        lastGoal = justReached;
    }


    /**void ActivateRandomFlame()
    {
        // Désactiver toutes les flammes
        foreach (GameObject goal in goals)
        {
            goal.transform.Find("VFX_Fire").gameObject.SetActive(false);
        }

        // Sélection aléatoire d’un nouveau but
        int randomIndex = Random.Range(0, 4);
        currentGoal = goals[randomIndex];

        // Activer la flamme de celui-là
        currentGoal.transform.Find("VFX_Fire").gameObject.SetActive(true);
    }**/
}
