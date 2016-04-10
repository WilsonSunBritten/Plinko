using UnityEngine;
using System.Collections;

public class GameEnder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(transform.position.y > 5 || transform.position.y < -10)
        {
           DestroyObject(gameObject);
        }
	}

    void gameOver()
    {
    }
}
