using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CTouchDrogMoveController : MonoBehaviour 
{
    public GameObject _player;
    //private Vector3 initMousePos;


    Vector3 initMousePos;


    void Update()
    {
        if (Input.GetTouch(0).fingerId == 0)
        {

            if (Input.GetTouch(0).phase == TouchPhase.Began )
            {
                initMousePos = Input.GetTouch(0).position;
                initMousePos.z = 10;
                initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);

                
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector3 worldPoint = Input.GetTouch(0).position;
                worldPoint.z = 10;
                worldPoint = Camera.main.ScreenToWorldPoint(worldPoint);

                Vector3 diffPos = worldPoint - initMousePos;

                diffPos.z = 0;
                

                initMousePos = Input.GetTouch(0).position;
                initMousePos.z = 10;
                initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);

                _player.transform.position = new Vector3(Mathf.Clamp(_player.transform.position.x + diffPos.x, -4.5f, 4.5f), Mathf.Clamp(_player.transform.position.y + diffPos.y, -4.5f, 4.5f), (
                                _player.transform.position.z));
            }

        }
    }   
}


