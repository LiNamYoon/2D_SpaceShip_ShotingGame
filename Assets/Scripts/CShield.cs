using UnityEngine;
using System.Collections;

public class CShield : MonoBehaviour 
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Enemy")|| col.tag.Equals("ESLaser"))
        {
            Destroy(col.gameObject);
            ShieldHp();
            
        }

    }	
    void ShieldHp()
    {
        Color ShieldColor = GetComponent<SpriteRenderer>().color;
        ShieldColor -= new Color(0, 0, 0, 0.2f);
        GetComponent<SpriteRenderer>().color = ShieldColor;

        //Debug.Log("현재 쉴드 투명도 : " + ShieldColor.a);

        if (ShieldColor.a <= 0.2)
        {
            ShieldColor.a = 1;
            GetComponent<SpriteRenderer>().color = ShieldColor;
            //Debug.Log("쉴드 색상" + GetComponent<SpriteRenderer>().color.ToString());
            gameObject.SetActive(false);
            Debug.Log("쉴드 끝 : " + gameObject.activeSelf.ToString());
        }
    }

	void Update () 
	{
	    
	}

	void SetReference()
	{
		
	}
}


