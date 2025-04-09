using UnityEngine;

public class FlameManager : MonoBehaviour
{
    public GameObject[] goals; // Objectifs avec feu (Box_01)
    public GameObject currentGoal; // Actuel but allum�
    public float timeBetweenFlames = 1f; // Temps avant de changer

    private void Start()
    {
        InvokeRepeating(nameof(ActivateRandomFlame), 0f, timeBetweenFlames);
    }

    void ActivateRandomFlame()
    {
        // D�sactiver toutes les flammes
        foreach (GameObject goal in goals)
        {
            goal.transform.Find("VFX_Fire").gameObject.SetActive(false);
        }

        // S�lection al�atoire d�un nouveau but
        int randomIndex = Random.Range(0, 4);
        currentGoal = goals[randomIndex];

        // Activer la flamme de celui-l�
        currentGoal.transform.Find("VFX_Fire").gameObject.SetActive(true);
    }
}
