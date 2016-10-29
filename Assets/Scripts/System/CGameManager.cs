using UnityEngine;
using System.Collections;

public class CGameManager : MonoBehaviour 
{
    public static bool IsBossStageClear = false;
    public static bool GameOver = false;
    public static bool GameStart = false;

    public static int StageNum;
	void Start ()
	{
        IsBossStageClear = false;
        GameOver = false;
        GameStart = false;
    }
		
	void Update () 
	{
	
	}

	void SetReference()
	{
		
	}
}


