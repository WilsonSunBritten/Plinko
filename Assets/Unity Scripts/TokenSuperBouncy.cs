using UnityEngine;
using System.Collections;

public class TokenSuperBouncy : MonoBehaviour {
	public bool triggered;


	// Use this for initialization
	void Start () {
		triggered = false;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (!triggered && col.gameObject.tag == "Token") {
			CircleCollider2D myCollider = col.gameObject.GetComponent<CircleCollider2D>();
            myCollider.sharedMaterial = (PhysicsMaterial2D) Resources.Load("SuperBouncyMaterial");
			triggered = true;

			SpriteRenderer myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
			myRenderer.color = Color.white;
		}
	}
}
