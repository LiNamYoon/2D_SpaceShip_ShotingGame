using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CStageManager : MonoBehaviour 
{
    public Slider _stagePlayTimeGage;
    public float[] _stageClearTimes;

    public GameObject StageClearEffect;
    public GameObject BossStageStartEffect;
    
    public GameObject[] BossPrefab;
    public Transform BossGenPos;
    public GameObject[] EnemyGeneration;
    public Text StageNumText;
    float PlayTime;
    int ClearTimeIndexValue;

    void Start ()
	{
        _stagePlayTimeGage.maxValue = _stageClearTimes[0];
        ClearTimeIndexValue = 0;

        Screen.SetResolution(405, 720, false);
    }

    void Update () 
	{
        //Debug.Log(i + " 번째 배열 / " + ClearTime[i].ToString());
        if(!GameObject.FindGameObjectWithTag("Boss"))
        {
            PlayTime += Time.deltaTime;

            _stagePlayTimeGage.value = PlayTime;
        }
        
        if (PlayTime >= _stageClearTimes[ClearTimeIndexValue] 
            && CGameManager.IsBossStageClear == false)
        {
            if(CGameManager.StageNum >= BossPrefab.Length)
            {
                CGameManager.IsBossStageClear = true;
            }
            else
            {
                //Debug.LogWarning("스테이지 클리어");
                // 클리어 UI 출력
                CBossPatternSystem.BossAIStart = true;
                StartCoroutine("BossStageStartCoroutine");
                CGameManager.IsBossStageClear = true;
            } 
            

        }
        

        if (PlayTime >= _stageClearTimes[ClearTimeIndexValue] 
            && CGameManager.IsBossStageClear == true 
            && !CBossPatternSystem.BossAIStart 
            && CBossPatternSystem.BossStageClearCheck)
        {

            CBossPatternSystem.BossStageClearCheck = false;
            //Debug.Log("새로운 스테이지 시작");
            
            StartCoroutine("NextStageStartCoroutine");
        }
    }
    IEnumerator BossStageStartCoroutine()
    {
        foreach (GameObject Gen in EnemyGeneration)
        {
            Gen.SetActive(false);
        }
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemys.Length; i++)
        {
            Destroy(enemys[i]);
        }
        GameObject[] enemyLasers = GameObject.FindGameObjectsWithTag("ESLaser");
        for (int i = 0; i < enemyLasers.Length; i++)
        {
            Destroy(enemyLasers[i]);
        }


        GameObject Effect = Instantiate(BossStageStartEffect, Vector2.zero, Quaternion.identity) as GameObject;
        Effect.transform.SetParent(GameObject.Find("Canvas").transform, false);
        Destroy(Effect, 5f);
        yield return new WaitForSeconds(7);
        Instantiate(BossPrefab[CGameManager.StageNum], BossGenPos.position, Quaternion.identity);

        StopCoroutine("BossStageStartCoroutine");
    }

    IEnumerator NextStageStartCoroutine()
    {
        yield return new WaitForSeconds(1);
        CGameManager.StageNum++;

        StageNumText.text = "Stage " + CGameManager.StageNum;
        GameObject Effect = Instantiate(StageClearEffect, Vector2.zero, Quaternion.identity) as GameObject;
        Effect.transform.SetParent(GameObject.Find("Canvas").transform, false);
        Destroy(Effect, 3f);

        GameObject[] enemyLasers = GameObject.FindGameObjectsWithTag("ESLaser");
        for (int i = 0; i < enemyLasers.Length; i++)
        {
            Destroy(enemyLasers[i]);
        }

        ClearTimeIndexValue++;      

        yield return new WaitForSeconds(5);
        CGameManager.IsBossStageClear = false;
        PlayTime = 0;
        _stagePlayTimeGage.maxValue = _stageClearTimes[ClearTimeIndexValue];


        foreach (GameObject Gen in EnemyGeneration)
        {
            Gen.SetActive(true);
        }

        StopCoroutine("StageStartCoroutine");
        
    }

}


