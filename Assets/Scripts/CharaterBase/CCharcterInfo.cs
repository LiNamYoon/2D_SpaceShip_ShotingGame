using UnityEngine;
using System.Collections;

public class CCharcterInfo : MonoBehaviour 
{
    public string _name;
    public float _hp;
    //public float _speed;
    public float _damage;
    
    public GameObject enemyDeadEffect;
    void Update()
    {
        if (_hp <= 0)
        {
            if(gameObject.tag.Equals("Boss"))
            {
                Debug.LogWarning("여기요");
                CBossPatternSystem.BossDead = true;
            }

            Object EnemyDeadEffect = Instantiate(enemyDeadEffect, transform.position, Quaternion.identity);
            
            Destroy(EnemyDeadEffect);
            if (GetComponent<CItemGeneration>() != null)
            {
                if(GetComponent<CItemGeneration>()._Dead == false)
                {
                    GetComponent<CItemGeneration>().DeadIItemGen(true);
                }
            }
            if (!gameObject.tag.Equals("Boss"))
            {
                Destroy(gameObject);
            }
           

        }
    }

	
}


