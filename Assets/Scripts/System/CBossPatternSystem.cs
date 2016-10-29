using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CBossPatternSystem : MonoBehaviour 
{
    // 기본 지정 속도
    public float _speed;

    public static bool BossAIStart = false;
    public static bool BossDead = false;

    public static bool BossStageClearCheck = false;

    public string[] PatturnName;
    public static int BossPatturnSwitchValue;

    private Vector2 BossNowPos;
    public Vector2[] BossMovePos;

    int BossMovePosIndexValue;
    int BossPatturnSwitchStartCheckValue;


    void Start ()
	{

        

        BossDead = false;
        
        BossStageClearCheck = false;
        BossPatturnSwitchValue = 0;
        BossMovePosIndexValue = 0;
        BossPatturnSwitchStartCheckValue = 0;
    }
		
	void Update () 
	{
        // 보스의 현재 위치를 지속적으로 체크
        BossNowPos = transform.position;


        if (BossAIStart)
        {

            // 보스 이동 패턴
            switch (BossPatturnSwitchValue)
            {
                case 0 :
                   
                    transform.position = Vector2.MoveTowards(BossNowPos, BossMovePos[BossMovePosIndexValue], _speed * Time.deltaTime);
                    if(BossNowPos == BossMovePos[BossMovePosIndexValue])
                    {
                        BossPatturnSwitchValue++;
                        BossMovePosIndexValue = BossPatturnSwitchValue;
                        
                    }
                    break;
                case 1:
                   
                    transform.position = Vector2.MoveTowards(BossNowPos, BossMovePos[BossMovePosIndexValue], _speed * Time.deltaTime);
                    if (BossNowPos == BossMovePos[BossMovePosIndexValue])
                    {
                        BossPatturnSwitchValue++;
                        BossMovePosIndexValue = BossPatturnSwitchValue;
                       
                    }
                    break;
                case 2:
                    transform.position = Vector2.MoveTowards(BossNowPos, BossMovePos[BossMovePosIndexValue], _speed * Time.deltaTime);
                    if (BossNowPos == BossMovePos[BossMovePosIndexValue])
                    {
                        BossPatturnSwitchValue++;
                        BossMovePosIndexValue = BossPatturnSwitchValue;
                    }
                    break;
                case 3:
                    transform.position = Vector2.MoveTowards(BossNowPos, BossMovePos[BossMovePosIndexValue], _speed * Time.deltaTime);
                    if (BossNowPos == BossMovePos[BossMovePosIndexValue])
                    {
                        BossPatturnSwitchValue++;
                        BossMovePosIndexValue = BossPatturnSwitchValue;
                    }
                    break;

                default:
                    BossPatturnSwitchValue = 0;
                    BossMovePosIndexValue = BossPatturnSwitchValue;
                    Debug.LogWarning("보스 이동 패턴 스위치 초기화!!!"); break;
            }

            // 보스 공격 패턴
            switch (BossPatturnSwitchValue)
            {
                
                case 0:

                    if (BossPatturnSwitchStartCheckValue == 0)
                    {
                        gameObject.SendMessage(PatturnName[3] + "Stop");
                        gameObject.SendMessage(PatturnName[BossPatturnSwitchStartCheckValue] + "Start");
                        
                        BossPatturnSwitchStartCheckValue++;
                    }
                    break;


                case 1:
                    
                    if (BossPatturnSwitchStartCheckValue == 1)
                    {
                        gameObject.SendMessage(PatturnName[0] + "Stop");
                        gameObject.SendMessage(PatturnName[BossPatturnSwitchStartCheckValue] + "Start");
                        
                        BossPatturnSwitchStartCheckValue++;
                    }
                    
                    break;
                case 2:
                    
                    if (BossPatturnSwitchStartCheckValue == 2)
                    {
                        gameObject.SendMessage(PatturnName[1] + "Stop");
                        gameObject.SendMessage(PatturnName[BossPatturnSwitchStartCheckValue] + "Start");
                        
                        BossPatturnSwitchStartCheckValue++;
                    }

                    break;
                case 3:
                    
                    if (BossPatturnSwitchStartCheckValue == 3)
                    {
                        gameObject.SendMessage(PatturnName[2] + "Stop");
                        gameObject.SendMessage(PatturnName[BossPatturnSwitchStartCheckValue] + "Start");
                        
                        BossPatturnSwitchStartCheckValue++;
                    }

                    break;

                default:
                    BossPatturnSwitchStartCheckValue = 0;
                    Debug.LogWarning("보스 공격 패턴 스위치 초기화!!!"); break;
            }    
        }


        // 보스 죽음 && 스테이지 종료시간 안됨
        if(BossDead)
        {
            
            BossAIStart = false;
            BossStageClearCheck = true;
            Destroy(gameObject);
        }
   }
}


