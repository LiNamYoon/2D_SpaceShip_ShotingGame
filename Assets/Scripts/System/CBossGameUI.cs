using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CBossGameUI : MonoBehaviour 
{
    public Image HpGageHandleImage;
    public Sprite PlayerSprite;
    public Sprite BossSprite;
    public Slider BossHpGage;

    bool BossHpGageCheck =false;
    void Start ()
	{
	
	}
		
	void Update () 
	{
        if (!GameObject.FindGameObjectWithTag("Boss"))
        {
            HpGageHandleImage.sprite = PlayerSprite;
        }
        if (GameObject.FindGameObjectWithTag("Boss"))
        {
            HpGageHandleImage.sprite = BossSprite;
            if(CBossPatternSystem.BossAIStart && !BossHpGageCheck )
            {
                BossHpGageCheck = true;
                BossHpGage.maxValue = GameObject.FindGameObjectWithTag("Boss").GetComponent<CCharcterInfo>()._hp;
            }
            BossHpGage.value = GameObject.FindGameObjectWithTag("Boss").GetComponent<CCharcterInfo>()._hp;

            if(GameObject.FindGameObjectWithTag("Boss").GetComponent<CCharcterInfo>()._hp <= 0)
            {
                BossHpGageCheck = false;
            }

        }
	}

	void SetReference()
	{
		
	}
}


