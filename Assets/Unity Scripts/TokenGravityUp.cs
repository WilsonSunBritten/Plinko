using UnityEngine;
using System.Collections;

public class TokenGravityUp : MonoBehaviour {
	public bool triggered;
	public float triggerTime;
	public GameObject target;

	void Start() {
		triggered = false;
	}

	void Update() {
		if (triggered && (triggerTime + 10f) < Time.time) { 
			Debug.Log ("end");
			var myBody = target.GetComponent<Rigidbody2D>();
			myBody.gravityScale = myBody.gravityScale * 0.5f;
			triggered = false;
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (!triggered && col.gameObject.tag == "Token") {
			target = col.gameObject;
			var myBody = target.GetComponent<Rigidbody2D>();
			myBody.gravityScale = myBody.gravityScale * 2f;
			triggered = true;
			triggerTime = Time.time;

			SpriteRenderer myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
			myRenderer.color = Color.white;
		}
	}
}
