using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CMouseMoveController : MonoBehaviour 
{
    public GameObject _player;
    private GameObject _skillPanel;


    Vector3 initMousePos;
    
    public static bool MouseUpCheck = false;


    void Start()
    { 
        MouseUpCheck = false;

        _skillPanel = GameObject.Find("SkillChoicePanel");
    }

    void Update()
    {
        MouseCheck();





    }

    public void OnMouseDown()
    {
        if (!CGameManager.GameOver)
        {
            initMousePos = Input.mousePosition;
            initMousePos.z = 10;
            initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);


            StartCoroutine("test");

        }
    }

    IEnumerator test()
    {
        yield return new WaitForSeconds(0.1f);
        MouseUpCheck = false;

    }
    void OnMouseDrag()
    {
        if (!CGameManager.GameOver)
        {
            Vector3 worldPoint = Input.mousePosition;
            worldPoint.z = 10;
            worldPoint = Camera.main.ScreenToWorldPoint(worldPoint);

            Vector3 diffPos = worldPoint - initMousePos;

            diffPos.z = 0;


            initMousePos = Input.mousePosition;
            initMousePos.z = 10;
            initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);

            _player.transform.position = new Vector3(Mathf.Clamp(_player.transform.position.x + diffPos.x, -4.5f, 4.5f), Mathf.Clamp(_player.transform.position.y + diffPos.y, -4.5f, 4.5f), (
                            _player.transform.position.z));
        }

        
    }

    void OnMouseUp()
    {
        if (!CGameManager.GameOver)
        {
            MouseUpCheck = true;
        }
    }

    void MouseCheck()
    {
        if (MouseUpCheck)
        {
            Time.timeScale = 0.2F;
            _skillPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0F;
            
            _skillPanel.SetActive(false);
        }
    }
    
}


