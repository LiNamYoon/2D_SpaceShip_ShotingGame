using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CStartUI : MonoBehaviour 
{
    public Text ScoreText;

    void Start ()
	{
        Screen.SetResolution(405, 720, false);
    }
		
	void Update () 
	{
        ScoreText.text = PlayerPrefs.GetInt("BESTSCORE").ToString();
    }
    public void REStart()
    {
        SceneManager.LoadScene("Demo");
    }

}


