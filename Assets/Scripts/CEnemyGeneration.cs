using UnityEngine;
using System.Collections;

public class CEnemyGeneration : MonoBehaviour 
{

    public Transform[] _enemyGenPosArray;
    public GameObject[] _enemyArray;
    public float[] _enemyGenValue;
    public float _minDileyTime;
    public float _maxDileyTime;
    float RandomDileyTime;
    float TotalEnemyGenValue;




    void OnEnable()
    {
        StopCoroutine("EnemyGen");
        StartCoroutine("EnemyGen");
        for (int i = 0; i < _enemyGenValue.Length; i++)
        {
            TotalEnemyGenValue += _enemyGenValue[i];
        }
    }

    void OnDisable()
    {
        Debug.Log(gameObject.name + "코루틴 종료");
        StopCoroutine("EnemyGen");
    }

    IEnumerator EnemyGen()
    {
        Debug.Log(gameObject.name + "코루틴 실행중");
        while (true)
        {
            
            RandomDileyTime = Random.Range(_minDileyTime, _maxDileyTime);
            int EnemyGenPosIndex = Random.Range(0, _enemyGenPosArray.Length);
            
            float EnemyGenRandomValue = Random.Range(0, TotalEnemyGenValue);
            

            float SumEnemyGenValue = _enemyGenValue[0];
            if (EnemyGenRandomValue >= 0 && EnemyGenRandomValue <= _enemyGenValue[0])
            {
                Instantiate(_enemyArray[0], _enemyGenPosArray[EnemyGenPosIndex].position, Quaternion.identity);
            }
            else
            {
                for (int i = 1; i < _enemyGenValue.Length; i++)
                {
                    
                    if (EnemyGenRandomValue > SumEnemyGenValue && EnemyGenRandomValue <= SumEnemyGenValue + _enemyGenValue[i])
                    {
                        Instantiate(_enemyArray[i], _enemyGenPosArray[EnemyGenPosIndex].position, Quaternion.identity);
                    }
                    SumEnemyGenValue += _enemyGenValue[i];
                }
            }
            

            yield return new WaitForSeconds(RandomDileyTime);
            
        }
        
    }


}


