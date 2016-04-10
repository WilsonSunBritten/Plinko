using UnityEngine;
using System.Collections;

public class GoldenPeg : MonoBehaviour {

    public bool triggered;

    void Start()
    {
        triggered = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!triggered && col.gameObject.tag == "Token")
        {
            Score.score += 50;
            //PegGenerator.timeDiff = PegGenerator.timeDiff * .5;
            //PegLogic.verticalSpeed = PegLogic.verticalSpeed * 2f;

            triggered = true;

            SpriteRenderer myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
            myRenderer.color = Color.white;
        }
    }
}
