using UnityEngine;
using System.Collections;

public class TokenSizeUp : MonoBehaviour {
	public bool triggered;

	void Start () {
		triggered = false;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (!triggered && col.gameObject.tag == "Token") {
			Vector3 scale = col.gameObject.transform.localScale;
			scale.y = scale.y * 1.1f;
			scale.x = scale.x * 1.1f;
			col.gameObject.transform.localScale = scale;
			triggered = true;

			SpriteRenderer myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
			myRenderer.color = Color.white;
		}
	}
}
