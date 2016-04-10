using UnityEngine;
using System.Collections;

public class TokenSizeDown : MonoBehaviour {
	public bool triggered;

	void Start () {
		triggered = false;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (!triggered && col.gameObject.tag == "Token") {
			Vector3 scale = col.gameObject.transform.localScale;
            if (scale.y > .4)
            {
                scale.y = scale.y * 0.9f;
                scale.x = scale.x * 0.9f;
            }
                col.gameObject.transform.localScale = scale;
			triggered = true;

			SpriteRenderer myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
			myRenderer.color = Color.white;
		}
	}
}
