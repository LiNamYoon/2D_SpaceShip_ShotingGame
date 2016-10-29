using UnityEngine;
using System.Collections;

public class C_HalfFire : MonoBehaviour 
{
    public GameObject _weapon;
    public Transform[] _shotPos;
    public float _shotSpeed;

    void HalfFireStart()
    {
        StartCoroutine("HalfFireCoroutine");        
    }
    void HalfFireStop()
    {
        StopCoroutine("HalfFireCoroutine");
    }


    IEnumerator HalfFireCoroutine()
    {
        while (true)
        {
            for (int a = 0; a < _shotPos.Length; a++)
            {
                for (int i = 0; i < 90; i += 10)
                {
                    Instantiate(_weapon, _shotPos[a].position, Quaternion.Euler(0, 0, i));
                }
                for (int j = 270; j < 360; j += 10)
                {
                    Instantiate(_weapon, _shotPos[a].position, Quaternion.Euler(0, 0, j));
                }
            }

            yield return new WaitForSeconds(_shotSpeed);
        }
    }

}


