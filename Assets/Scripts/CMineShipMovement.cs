using UnityEngine;
using System.Collections;

public class CMineShipMovement : MonoBehaviour 
{
    private Transform PlayerShipPos;
    public float _speed;
    Vector2 _playerShip;

	void Start ()
	{
        SetReference();
    }
		
	void Update () 
	{
        

        _playerShip = (PlayerShipPos.position - transform.position);//.normalized;

        transform.Translate(_playerShip * _speed *Time.deltaTime);
	}

	void SetReference()
	{
        if (gameObject.name.Equals("RightMineShip(Clone)"))
        {
            PlayerShipPos = GameObject.Find("RightMineShipPos").GetComponent<Transform>();
        }
        if(gameObject.name.Equals("LeftMineShip(Clone)"))
        {
            PlayerShipPos = GameObject.Find("LeftMineShipPos").GetComponent<Transform>();
        }

    }
}


