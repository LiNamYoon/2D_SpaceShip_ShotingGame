using UnityEngine;
using System.Collections;

public class CGuideMovement : MonoBehaviour 
{
    public string targetName;
    private Transform _enemy;
    private GameObject _enemyTag;
    public float _speed;
    Vector2 Venemy;


    void Start()
    {
        _enemyTag = GameObject.FindGameObjectWithTag(targetName);

    }

    void Update()
    {
        if (_enemyTag == null)
        {
            transform.Translate(Vector2.up * _speed * Time.deltaTime);
            //Debug.LogWarning("타겟이 사라졌다.");
        }
        else if (_enemyTag.tag.Equals("Enemy") || _enemyTag.tag.Equals("Boss"))
        {
            if (_enemyTag == null)
            {
                transform.Translate(Vector2.up * _speed * Time.deltaTime);
                //Debug.LogWarning("타겟이 사라졌다.");
            }
            //Debug.LogWarning("적기 추격중");
            _enemy = GameObject.FindGameObjectWithTag(targetName).GetComponent<Transform>();
            Venemy = (_enemy.position - transform.position).normalized;
            transform.Translate(Venemy * _speed * Time.deltaTime);

            float rotationZ = Mathf.Atan2(Venemy.y, Venemy.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);
        }
        else if (_enemyTag.tag.Equals("Player"))
        {
            //Debug.LogWarning("플레이어 추격중");
            _enemy = GameObject.FindGameObjectWithTag(targetName).GetComponent<Transform>();
            Venemy = (_enemy.position - transform.position).normalized;
            transform.Translate(Venemy * _speed * Time.deltaTime);
        }






    }
}


