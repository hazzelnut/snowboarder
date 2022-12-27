using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            // PlayerController here is script with the class, but also a type
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            // In order to play multiple audios for crash, spin, boost, etc.
            // We can grab the AudioSource Component attached to 'Joe',
            // and sub in the audio files we want to play in the Unity Inspector
            // SerializeFields for AudioClips.
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", reloadDelay);
        }
    } 

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
