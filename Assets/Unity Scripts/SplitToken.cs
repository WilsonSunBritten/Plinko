using UnityEngine;
using System.Collections;

public class SplitToken : MonoBehaviour {
	public bool triggered;

	// Use this for initialization
	void Start () {
		triggered = false;
        SpriteRenderer myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        myRenderer.color = Color.blue;
    }


	void OnCollisionEnter2D (Collision2D col) {
		if (!triggered && col.gameObject.tag == "Token") {
            GameObject newToken =(GameObject) Resources.Load("Token");
            Instantiate(newToken, new Vector3(0, 5, 0), new Quaternion());
			triggered = true;

			SpriteRenderer myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
			myRenderer.color = Color.white;
		}
	}
}
