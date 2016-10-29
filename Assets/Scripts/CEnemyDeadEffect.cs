using UnityEngine;
using System.Collections;

public class CEnemyDeadEffect : MonoBehaviour 
{
    public GameObject _enemyDeadEffect;
    Object EnemyDeadEffectSprite;

    void Start ()
	{


    }
		
	void OnEnable() 
	{

        for (int i = 0; i < 360; i += 20)
        {
            EnemyDeadEffectSprite = Instantiate(_enemyDeadEffect, transform.position, Quaternion.Euler(0, 0, i));
            Destroy(EnemyDeadEffectSprite, 1f);
        }
	}


}


