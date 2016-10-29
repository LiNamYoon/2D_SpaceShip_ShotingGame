using UnityEngine;
using System.Collections;

public class C_BasicFire : MonoBehaviour 
{
    public GameObject _weapon;
    public Transform[] _shotPos;
    public float _shotSpeed;

    void BasicFireStart()
    {
        StartCoroutine("BasicFireCoroutine");
    }
    void BasicFireStop()
    {
        StopCoroutine("BasicFireCoroutine");
    }


    IEnumerator BasicFireCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < _shotPos.Length; i++)
            {
                Instantiate(_weapon, _shotPos[i].position, Quaternion.identity);

            }
            yield return new WaitForSeconds(_shotSpeed);
        }
    }
}


