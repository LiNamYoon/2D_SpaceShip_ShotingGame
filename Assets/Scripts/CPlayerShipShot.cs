using UnityEngine;
using System.Collections;

public class CPlayerShipShot : MonoBehaviour 
{
    public Transform[] _shotPos;
    public GameObject[] _WeaponPrefab;

    public int count;
    void Start ()
	{
        StartCoroutine("Shot");
	}
		
	void Update () 
	{
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }
        //InvokeRepeating("Shot", 0.5f, 2f);
        //Shot();
        //강화 아이템을 얼마나 먹었는가?
        // 몇개의 포문을 사용하는가
        // 어떤 무기를 사용하는가?
        // 출력

    }
    IEnumerator Shot()
    {
        while(true)
        {
            if (count == 0)
            {
                Instantiate(_WeaponPrefab[0], _shotPos[0].position, Quaternion.identity);
            }
            if (count == 1)
            {
                Instantiate(_WeaponPrefab[0], _shotPos[1].position, Quaternion.identity);
                Instantiate(_WeaponPrefab[0], _shotPos[2].position, Quaternion.identity);
            }
            if (count == 2)
            {
                Instantiate(_WeaponPrefab[0], _shotPos[0].position, Quaternion.identity);
                Instantiate(_WeaponPrefab[0], _shotPos[1].position, Quaternion.identity);
                Instantiate(_WeaponPrefab[0], _shotPos[2].position, Quaternion.identity);
            }
            if (count == 3)
            {
                Instantiate(_WeaponPrefab[0], _shotPos[0].position, Quaternion.identity);
                Instantiate(_WeaponPrefab[0], _shotPos[1].position, Quaternion.identity);
                Instantiate(_WeaponPrefab[0], _shotPos[2].position, Quaternion.identity);
                Instantiate(_WeaponPrefab[0], _shotPos[3].position, Quaternion.Euler(0, 0, 30f));
                Instantiate(_WeaponPrefab[0], _shotPos[4].position, Quaternion.Euler(0, 0, -30f));
            }

            yield return new WaitForSeconds(0.05f);
        }
        
    }
	void SetReference()
	{
		
	}
}


