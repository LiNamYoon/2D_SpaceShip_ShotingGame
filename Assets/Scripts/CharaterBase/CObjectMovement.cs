using UnityEngine;
using System.Collections;

public class CObjectMovement : MonoBehaviour 
{

    public Vector2 _movePos;
    public float _speed;

	void Start ()
	{
	
	}
		
	void Update () 
	{
        Move();

    }
    void Move()
    {
        transform.Translate(_movePos * _speed * Time.deltaTime);
    }

	void SetReference()
	{
		
	}
}


