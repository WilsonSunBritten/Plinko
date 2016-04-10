using UnityEngine;
using System.Collections;

public class PegLogic : MonoBehaviour {
    public bool ignoreTimescale;
    private float m_LastRealTime;
    private bool firstTime;
    private int oldScoreLevel = 0;
    private int levelDifference = 300;
    private float difficultyIncrease = 1.3f;
    public static float verticalSpeed = 1;
    // Use this for initialization
    void Start () {
        firstTime = true;
    }
	
	// Update is called once per frame
	void Update () {
	if(gameObject.transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    if(Score.score > oldScoreLevel+levelDifference)
        {
            oldScoreLevel = oldScoreLevel + levelDifference;
            verticalSpeed = verticalSpeed * difficultyIncrease;
        }
    
            if (firstTime)
            {
                firstTime = false;
                m_LastRealTime = Time.realtimeSinceStartup;

            }
            float deltaTime = Time.deltaTime;
            if (ignoreTimescale)
            {
                deltaTime = (Time.realtimeSinceStartup - m_LastRealTime);
                m_LastRealTime = Time.realtimeSinceStartup;
            }
            transform.Translate(new Vector3(0, 1f, 0) * deltaTime, Space.Self);
        
    
	}
}
