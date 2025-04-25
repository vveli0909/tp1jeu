using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(" Quelqu�un est entr� : " + other.name);
        if (other.CompareTag("Player"))
        {
            Animator anim = other.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetBool("Crawl", true);
                Debug.Log(" Entr�e en zone rampage");
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Animator anim = other.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetBool("Crawl", false);
                Debug.Log(" Sortie de zone rampage");
            }
        }
    }
}
