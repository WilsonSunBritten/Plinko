using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {
    AudioSource fxSound;
    bool isPaused;
    // Use this for initialization
    void Start() {
        isPaused = false;
    }

    // Update is called once per frame
    void Update() {}

    void ButtonClickedEvent()
    {
        Time.timeScale = 0f;

        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
        }
        isPaused = true;

    }

    public void Pause()
    {
        fxSound = GetComponent<AudioSource>();
        fxSound.Pause();
        Time.timeScale = 0f;

        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
            fxSound.UnPause();
        }else
            isPaused = true;
    }

    public void StartSound()
    {
        fxSound = GetComponent<AudioSource>();
    }
}
