using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public GUISkin layout;

    GameObject theBall;

    // Use this for initialization
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    public static void Score(string wallID)
    {
        if (wallID == "TopWall")
        {
            PlayerScore1++;
        }
        else
        {
            PlayerScore2++;
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 00, 100, 100), "SCORE");
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "Player 1: " + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 40, 100, 100), "Player 2: " + PlayerScore2);



        if (GUI.Button(new Rect(Screen.width / 2 - 60, 00, 120, 23), "QUIT"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }
        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2  + 50, 40, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            if (GUI.Button(new Rect(Screen.width / 2 + 60, 00, 120, 23), "RESTART"))
            {
                PlayerScore1 = 0;
                PlayerScore2 = 0;
                theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
            }
        }
        else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 + 50, 40, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            if (GUI.Button(new Rect(Screen.width / 2 + 60, 00, 120, 23), "RESTART"))
            {
                PlayerScore1 = 0;
                PlayerScore2 = 0;
                theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
            }
        }
    }

}