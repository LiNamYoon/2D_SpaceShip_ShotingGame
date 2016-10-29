using UnityEngine;
using System.Collections;

public class CItemGeneration : MonoBehaviour 
{

    public GameObject[] _genItmeArray;

    public float[] _ItemGenValue;
    public bool _Dead = false;

    float TotalItemGenValue;
    float EnemyGenRandomValue;

    void Start ()
	{
        for (int i = 0; i < _ItemGenValue.Length; i++)
        {
            TotalItemGenValue += _ItemGenValue[i];
        }

        EnemyGenRandomValue = Random.Range(0, TotalItemGenValue);
    }
		
	public void DeadIItemGen (bool Dead) 
	{
        _Dead = Dead;

        float SumEnemyGenValue = _ItemGenValue[0];
        if (EnemyGenRandomValue >= 0 && EnemyGenRandomValue <= _ItemGenValue[0])
        {
            Instantiate(_genItmeArray[0], transform.position, Quaternion.identity);
        }
        else
        {
            for (int i = 1; i < _ItemGenValue.Length; i++)
            {

                if (EnemyGenRandomValue > SumEnemyGenValue && EnemyGenRandomValue <= SumEnemyGenValue + _ItemGenValue[i])
                {
                    Instantiate(_genItmeArray[i], transform.position, Quaternion.identity);
                    //Debug.Log("랜덤 값 : " + EnemyGenRandomValue);
                    //Debug.Log(SumEnemyGenValue  + " <" + EnemyGenRandomValue + "<= " + (SumEnemyGenValue + _ItemGenValue[i]));
                    //Debug.Log(i + "번째 아이템 출력");
                    
                }
                SumEnemyGenValue += _ItemGenValue[i];
            }
        }
    }

	void SetReference()
	{
		
	}
}


