using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class reset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void resetGame()
    {
        SaveHighScore();


        Application.LoadLevel(Application.loadedLevel);
    }

    public void SaveHighScore()
    {
        if(Score.score > GetHighScore())
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

            int highScore = Score.score;

            bf.Serialize(file, highScore);
            file.Close();
        }
    }

    public int GetHighScore()
    {
        int highScore = 0;
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat")){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            highScore = (int)bf.Deserialize(file);
            file.Close();

            
        }
        return highScore;
    }
}
