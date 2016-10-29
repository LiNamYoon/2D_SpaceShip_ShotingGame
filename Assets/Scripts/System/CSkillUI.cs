using UnityEngine;
using System.Collections;

public class CSkillUI : MonoBehaviour 
{
    
    public float BombSkillSpeed;
    bool BombSkillStartCheck = false;
    float SkillTime;
    public GameObject EffectPrefab;

    void Start()
    {
        

    }
    public void BombSkill()
    {
        if(SkillTime >= 5)
        {
            BombSkillStartCheck = false;
            StopCoroutine("BombSkillCoroutine");
            SkillTime = 0;
            //Debug.Log("스킬 사용 끝");
        }
        StartCoroutine("BombSkillCoroutine");
        BombSkillStartCheck = true;
    }
    void Update()
    {
        if(BombSkillStartCheck)
        {
            //Debug.Log("스킬사용 시작");
            SkillTime += Time.deltaTime;
        }

    }

    IEnumerator BombSkillCoroutine()
    {
        GameObject[] Enmeys = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject Boss = GameObject.FindGameObjectWithTag("Boss");
        while (true)
        {
            if(Enmeys != null)
            {
                for (int i = 0; i < Enmeys.Length; i++)
                {
                    Enmeys[i].SendMessage("Attack", 2f);
                    GameObject ef = Instantiate(EffectPrefab, Enmeys[i].transform.position, Quaternion.identity) as GameObject;
                    Destroy(ef, 0.3f);
                }
            }
            if(Boss != null)
            {
                Boss.SendMessage("Attack", 5f);
                GameObject ef1 = Instantiate(EffectPrefab, Boss.transform.position, Quaternion.identity) as GameObject;
                Destroy(ef1, 0.3f);
            }

            yield return new WaitForSeconds(BombSkillSpeed);
        }
    }




	void SetReference()
	{
		
	}
}


