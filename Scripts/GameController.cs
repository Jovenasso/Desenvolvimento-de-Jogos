using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class GameController : MonoBehaviour
{
    public int totalScore;
    //public GameObject Apple00;
    //public GameObject Apple01;
    //public GameObject Apple02;
    //public GameObject Apple03;
    //public GameObject Apple04;
    //public GameObject Apple05;
    //public GameObject Apple06;
    //public GameObject Apple07;
    //public GameObject Apple08;
    //public GameObject Apple09;
    //public GameObject Apple10;
    //public GameObject Apple11;
    //public GameObject Apple12;
    //public GameObject Apple13;
    //public GameObject Apple14;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI qtdePlayersText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI finalScoreText;

    public static GameController instance;

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    public GameObject Talk1;
    public GameObject Talk2;
    public GameObject Talk3;
    public GameObject Talk4;
    public GameObject Talk5;
    

    private static bool statusPlayer1;
    private static bool statusPlayer2;
    private static bool statusPlayer3;
    private static bool statusPlayer4;

    private int qtdePlayers;

    public GameObject LorePage;
    public GameObject ParticipantsPage;
    public GameObject HomePage;

    public int time;

    public GameObject StartContainer;

    private static bool playersDefined = false;

    private Animator anim;
    
    public string lvlName;
    private string valueTotalS;
    private int valueTotalI;
    private int value;

    public GameObject winScreen;
    public GameObject defeatScreen;
    
    private static bool gameEnd = false;

    public int scoreToWin;

    void Start()
    {
        instance = this;
        if(playersDefined)
        {
            if(gameEnd)
            {
                loadScore();
                UpdateFinalScoreText();
                verifyWin();
            }
            else
            {
                StartCoroutine(CountTime());
                spawnPlayers();
                loadScore();
                UpdateScoreText();
                UpdateTimeText();
            }
        }
        
    }


    IEnumerator CountTime()
    {
        while(time>0)
        {
            time -= 1;
            //Debug.Log("time");
            UpdateTimeText();
            yield return new WaitForSeconds(1f);
        }

        if(time == 0)
        {
            if(lvlName == "Final")
            {
                SaveScore();
                gameEnd = true;
                SceneManager.LoadScene("Final");
            }
            else if(lvlName == "null")
            {
                Debug.Log("...");
            }
            else
            {
                SaveScore();
                SceneManager.LoadScene(lvlName);
            }
        }
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

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void UpdateQtdePlayersText()
    {
        qtdePlayersText.text = qtdePlayers.ToString();
    }

    public void UpdateFinalScoreText()
    {
        finalScoreText.text = totalScore.ToString();
    }

    public void UpdateTimeText()
    {
        timeText.text = time.ToString();
    }

    public void addPlayer1()
    {
        if(statusPlayer1)
        {
            statusPlayer1 = false;
            qtdePlayers -= 1;
        }
        else
        {
            statusPlayer1 = true;
            qtdePlayers += 1;
        }

        UpdateQtdePlayersText();
    }

    public void addPlayer2()
    {
        if(statusPlayer2)
        {
            statusPlayer2 = false;
            qtdePlayers -= 1;
        }
        else
        {
            statusPlayer2 = true;
            qtdePlayers += 1;
        }
        
        UpdateQtdePlayersText();
    }

    public void addPlayer3()
    {
        if(statusPlayer3)
        {
            statusPlayer3 = false;
            qtdePlayers -= 1;
        }
        else
        {
            statusPlayer3 = true;
            qtdePlayers += 1;
        }
        
        UpdateQtdePlayersText();
    }

    public void addPlayer4()
    {
        if(statusPlayer4)
        {
            statusPlayer4 = false;
            qtdePlayers -= 1;
        }
        else
        {
            statusPlayer4 = true;
            qtdePlayers += 1;
        }
        
        UpdateQtdePlayersText();
    }

    public void openLore()
    {
        LorePage.SetActive(true);
        HomePage.SetActive(false);
    }

    public void openParticipants()
    {
        ParticipantsPage.SetActive(true);
        HomePage.SetActive(false);
    }

    public void backHome()
    {
        HomePage.SetActive(true);
        ParticipantsPage.SetActive(false);
        LorePage.SetActive(false);
    }

    public void backMenu()
    {
        SceneManager.LoadScene("Menu");
        statusPlayer1 = false;
        statusPlayer2 = false;
        statusPlayer3 = false;
        statusPlayer4 = false;
        qtdePlayers = 0;
    }
    

    public void spawnPlayers()
    {

        if(statusPlayer1)
        {
            Player1.SetActive(true);
        }
        else
        {
            Player1.SetActive(false);
        }

        if(statusPlayer2)
        {
            Player2.SetActive(true);
        }
        else
        {
            Player2.SetActive(false);
        }

        if(statusPlayer3)
        {
            Player3.SetActive(true);
        }
        else
        {
            Player3.SetActive(false);
        }

        if(statusPlayer4)
        {
            Player4.SetActive(true);
        }
        else
        {
            Player4.SetActive(false);
        }  

    }

    public void startGame()
    {
        SceneManager.LoadScene("Fase01_Level01");
        playersDefined = true;
        clearScore();
    }

    public void macFei()
    {
        SceneManager.LoadScene("MacFei");
    }

    void clearScore()
    {
        string path = Application.persistentDataPath + "/RAM.txt";

        File.WriteAllText(path, "0");
    }

    void clearTime()
    {
        string path = Application.persistentDataPath + "/TIME.txt";

        File.WriteAllText(path, "0");
    }

    void loadScore()
    {
        string path = Application.persistentDataPath + "/RAM.txt";

        StreamReader reader = new StreamReader(path);

        totalScore = int.Parse(reader.ReadLine());

        reader.Close();

        clearScore();
    }
    
    public void nextTalk1()
    {
        Talk1.SetActive(false);
        Talk2.SetActive(true);
    }

    public void nextTalk2()
    {
        Talk2.SetActive(false);
        Talk3.SetActive(true);
    }

    public void nextTalk3()
    {
        Talk3.SetActive(false);
        Talk4.SetActive(true);
    }

    public void nextTalk4()
    {
        Talk4.SetActive(false);
        Talk5.SetActive(true);
    }

    public void verifyWin()
    {
        if(totalScore > scoreToWin)
        {
            winScreen.SetActive(true);
        }
        else if(totalScore < scoreToWin)
        {
            defeatScreen.SetActive(true);
        }
    }

    public void Continue()
    {
        SceneManager.LoadScene("Demo");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
