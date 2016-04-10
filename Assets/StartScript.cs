using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
        Time.timeScale = 0f;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startGame()
    {

        Time.timeScale = 1f;
        DestroyObject(GameObject.Find("Panel"));
        

    }
}
