using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PegGenerator : MonoBehaviour {
    private Transform[] prefabf;
    public GameObject prefab;// = GameObject.Find("SplitPeg");
    public GameObject SplitPeg;
    private float start;
    private GameObject peg;
    int i;
    int num = 5;
    float xmin = -3.2f;
    float xmax = 3.5f;
    float y = -6;
    float xmin1;
    float xdiff;
    float xmin2;
    float xmin3;
    float xmin4;
    float xmin5;
    float max1 = 10;
    float max2 = 10;
    float max3 = 10;
    float max4 = 10;
    private float force = 9.8f;
    bool timeChanged;
    public static double timeDiff;
    int level2;

    private int oldScoreLevel = 0;
    private int levelDifference = 300;
    private float difficultyIncrease = 1/1.3f;
    private float spawnRate = 1;
    // Use this for initialization
    void Start () {
        xmin1 = -3.2f;
        xdiff = (3.5f - (-3.2f)) / 4;
        xmin2 = xmin1 + xdiff;
        xmin3 = xmin2 + xdiff;
        xmin4 = xmin3 + xdiff;
        xmin5 = xmin4 + xdiff;
        i = 0;
        timeDiff = 1;
        level2 = 100;
        peg = (GameObject)Resources.Load("Peg");

        for(int j = 0; j < 8; j+=2)
        {
            Instantiate(peg, new Vector3(xmin + .5f, 2-j, 0), new Quaternion());
            Instantiate(peg, new Vector3(xmin3 + .5f, 2-j, 0), new Quaternion());
            Instantiate(peg, new Vector3(xmin2 + .5f, 2-j, 0), new Quaternion());
            Instantiate(peg, new Vector3(xmin + 2, 2-j-1.5f, 0), new Quaternion());
            Instantiate(peg, new Vector3(xmin2 +2, 2-j-1.5f, 0), new Quaternion());
            Instantiate(peg, new Vector3(xmin3 + 2, 2-j-1.5f, 0), new Quaternion());
        }
        //peg = GameObject.FindGameObjectWithTag("Peg");

        //Instantiate(peg, new Vector3(-2.3f, 4, 0), new Quaternion());
        


        start = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        if (Score.score > levelDifference+oldScoreLevel)
        {
            oldScoreLevel = levelDifference + oldScoreLevel;
            timeDiff = timeDiff * difficultyIncrease;
        }

        if (GameObject.FindWithTag("Token") == null)
        {
            SaveHighScore();
            Application.LoadLevel(Application.loadedLevel);
        }

        
        for (int h = 0; h < 2; h++)
        {

        
        int rand = (int)Random.Range(1, 20);
        if (rand == 2)
        {
            peg = (GameObject)Resources.Load("SplitPeg");
            //Instantiate(Resources.Load("SplitPeg"), new Vector3(Random.Range(xmin1, xmin5 + 1), y, 0), new Quaternion());
        }
        else if(rand == 3)
        {
            peg = (GameObject)Resources.Load("SuperBouncy");
        }
        else if(rand == 4)
            {
                peg = (GameObject)Resources.Load("ShrinkerPeg");
            }
        else if(rand == 5)
            {
                peg = (GameObject)Resources.Load("GrowPeg");
            }
        else if(rand == 6)
            {
                peg = (GameObject)Resources.Load("CursedPeg");
            }
        else if(rand == 7)
            {
                peg = (GameObject)Resources.Load("GoldenPeg");
            }
        else
            peg = (GameObject)Resources.Load("Peg");
        //transform.Translate(.05f, 0, 0);
        
        transform.Translate(.1f*Input.acceleration.x, 0, 0);
            if (start + timeDiff < Time.time)
            {
                timeChanged = true;

                float vertical = Random.Range(-.5f, .5f) + y;
                switch ((int)Mathf.Floor(Random.Range(1, 5)))
                {
                    case 1:
                        Instantiate(peg, new Vector3(Random.Range(xmin1, xmin2), vertical, 0), new Quaternion());
                        break;
                    case 2:
                        Instantiate(peg, new Vector3(Random.Range(xmin2, xmin3), vertical, 0), new Quaternion());
                        break;
                    case 3:
                        Instantiate(peg, new Vector3(Random.Range(xmin3, xmin4), vertical, 0), new Quaternion());
                        break;
                    default:
                        Instantiate(peg, new Vector3(Random.Range(xmin4, xmin5), vertical, 0), new Quaternion());
                        break;
                }
            }


            
            //Instantiate(peg, new Vector3(Random.Range(xmin, xmax), y, 0), new Quaternion());
        }
        if (timeChanged)
        {
            start = Time.time;
            timeChanged = false;
        }
        
	}
    public void SaveHighScore()
    {
        if (Score.score > GetHighScore())
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
