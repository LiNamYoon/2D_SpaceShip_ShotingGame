using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CPlayerUI : MonoBehaviour 
{
    public Slider HpGage;
    public Text ScoreText;
    public GameObject GameOverPanel;
    int BestScore;
	void Start ()
	{
        Screen.SetResolution(Screen.width, Screen.width * 9 / 16, true);
        GameOverPanel.SetActive(false);
        HpGage.maxValue = GameObject.Find("PlayerShip").GetComponent<CCharcterInfo>()._hp;
        HpGage.value = HpGage.maxValue;
    }
		
	void Update () 
	{

        HpGage.value = GameObject.Find("PlayerShip").GetComponent<CCharcterInfo>()._hp;
        ScoreText.text = GameObject.Find("PlayerShip").GetComponent<CPlayerShipCollision>()._starCountText.text;
        if (GameObject.Find("PlayerShip").GetComponent<CCharcterInfo>()._hp <=0)
        {
            CGameManager.GameOver = true;
            GameOverPanel.SetActive(true);
        }

        if (int.Parse(ScoreText.text) > PlayerPrefs.GetInt("BESTSCORE"))
        {
            BestScore = int.Parse(ScoreText.text);
            PlayerPrefs.SetInt("BESTSCORE", BestScore);
            PlayerPrefs.Save();
        }
    }
    
    public void REStart()
    {
        
        // static 변수 초기화
        CGameManager.StageNum = 0;
        CGameManager.IsBossStageClear = false;
        CGameManager.GameOver = false;
        CBossPatternSystem.BossDead = false;
        CBossPatternSystem.BossAIStart = false;
        CBossPatternSystem.BossPatturnSwitchValue = 0;
        CBossPatternSystem.BossStageClearCheck = false;

        SceneManager.LoadScene("Demo");

    }
}


