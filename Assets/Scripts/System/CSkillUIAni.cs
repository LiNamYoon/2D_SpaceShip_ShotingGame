using UnityEngine;
using System.Collections;

public class CSkillUIAni : MonoBehaviour 
{
    Animator _skillUIPanelAni;

    void OnEnable()
    {
        _skillUIPanelAni = GetComponent<Animator>();
        _skillUIPanelAni.Play("SkillPanelAni");
    }
    void OnDisable()
    {

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


