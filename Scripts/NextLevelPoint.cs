using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class NextLevelPoint : MonoBehaviour
{
    
    public string lvlName;

    private string valueTotalS;
    private int valueTotalI;
    private int value;

    void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(lvlName);
        }

        SaveScore();

    }

    void SaveScore()
    {
        string path = Application.persistentDataPath + "/RAM.txt";

        StreamReader reader = new StreamReader(path);

        Debug.Log(valueTotalS);

        valueTotalS = reader.ReadLine();

        valueTotalI = int.Parse(valueTotalS);

        reader.Close();

        StreamWriter writer = new StreamWriter(path, true);

        value = GameController.instance.totalScore;

        valueTotalI += value;

        writer.WriteLine(valueTotalI.ToString());

        writer.Close();

        Debug.Log(valueTotalI);

        GameController.instance.totalScore = valueTotalI;
    }

    
}
