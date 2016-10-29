using UnityEngine;
using System.Collections;

public class CAutoAtteck : MonoBehaviour 
{
    public GameObject _weapon;
    public Transform _shotPos;
    
    public float _shotSpeed;

    void Start ()
	{
        StartCoroutine("AutoAtteck");
	}
		
	IEnumerator AutoAtteck()
    {
        if(gameObject.tag.Equals("Enemy"))
        {
            if(gameObject.name.Equals("180FireEnemy(Clone)"))
            {
                while (true)
                {
                    
                    for (int i = 0; i < 90; i += 10)
                    {
                        Instantiate(_weapon, _shotPos.position, Quaternion.Euler(0, 0, i));
                    }
                    for (int j = 270; j < 360; j += 10)
                    {
                        Instantiate(_weapon, _shotPos.position, Quaternion.Euler(0, 0, j));
                    }
                    yield return new WaitForSeconds(_shotSpeed);
                }
            }
            if (gameObject.name.Equals("FireEnemy(Clone)"))
            {
                while (true)
                {
                    
                    Instantiate(_weapon, _shotPos.position, Quaternion.identity);
                    yield return new WaitForSeconds(_shotSpeed);
                }
            }
        }
        if (gameObject.tag.Equals("MineShip"))
        {
            while (true)
            {
                yield return new WaitForSeconds(_shotSpeed);
                Instantiate(_weapon, _shotPos.position, Quaternion.identity);
            }
        }


        
    }

	void SetReference()
	{
		
	}
}


