using UnityEngine;
using System.Collections;

public class CEffectRandomMovement : MonoBehaviour 
{
    Vector2 _movePos;
    public float _speed;
    float RandomNum;
    void Start()
    {
        RandomNum = Random.Range(1, 10);
    }

    void Update()
    {
        Move();

    }
    void Move()
    {
        
        _movePos = new Vector2(0, RandomNum);
        transform.Translate(_movePos * _speed * Time.deltaTime);
    }

    void SetReference()
    {

    }
}


