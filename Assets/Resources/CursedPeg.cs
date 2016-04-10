using UnityEngine;
using System.Collections;

public class CursedPeg : MonoBehaviour {


    public bool triggered;

    void Start()
    {
        triggered = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!triggered && col.gameObject.tag == "Token")
        {
            Score.accelerometerDirection = Score.accelerometerDirection * -1;


            triggered = true;

            SpriteRenderer myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
            myRenderer.color = Color.white;
        }
    }
}
