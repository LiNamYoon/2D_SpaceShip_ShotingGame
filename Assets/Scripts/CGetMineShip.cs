using UnityEngine;
using System.Collections;

public class CGetMineShip : MonoBehaviour 
{
    public Transform[] _getPos;
    public GameObject[] _mineShip;

    void Start ()
	{
	    
	}
		
	void Update () 
	{
        // 미니 쉽 생성 테스트용 
	    if(Input.GetKeyDown(KeyCode.V))
        {
            GetMineShip();
        }
	}
    public void GetMineShip()
    {
        for (int i = 0; i < _mineShip.Length; i++)
        {
            Instantiate(_mineShip[i], _getPos[i].position, Quaternion.identity);
        }
    }

	void SetReference()
	{
		
	}
}


