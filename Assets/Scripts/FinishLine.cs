using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;

    bool hasFinished;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !hasFinished)
        {
            hasFinished = true;
            finishEffect.Play();
            // Since there's only one audio file attached
            // to finish line component, we can just get the component.
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", reloadDelay);
        }
    } 

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
