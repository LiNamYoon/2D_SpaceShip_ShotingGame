using UnityEngine;
using System.Collections;

public class CEnemyShipCollision : MonoBehaviour 
{
    public CCharcterInfo _characterInfo;

    public GameObject _effectPrefab;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Space")) return;

        if (col.tag.Equals("Player"))
        {
            float Damage = col.GetComponent<CCharcterInfo>()._damage;
            Attack(Damage);
        }
        if (col.tag.Equals("PSLaser"))
        {
            float Damage = col.GetComponent<CCharcterInfo>()._damage;
            _characterInfo._hp -= Damage;

            GameObject Effect = Instantiate(_effectPrefab, col.transform.position, Quaternion.identity) as GameObject;
            Destroy(Effect, 0.3f);
            Destroy(col.gameObject);
        }
    }


    public void Attack(float Damage)
    {
        
        _characterInfo._hp -= Damage;
    }
    void Start ()
	{
	
	}
		
	void Update () 
	{
	
	}

	void SetReference()
	{
		
	}
}


