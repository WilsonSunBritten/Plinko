using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class HighScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text text = GetComponent<Text>();

        text.text = "Highscore: " + GetHighScore();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int GetHighScore()
    {
        int highScore = 0;
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            highScore = (int)bf.Deserialize(file);
            file.Close();


        }
        return highScore;
    }
}
