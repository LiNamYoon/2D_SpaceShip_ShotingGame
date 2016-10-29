using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CPlayerShipCollision : MonoBehaviour 
{

    public Animator _cameraAnimator;
    public Animator _playerAnimator;

    public Text _starCountText;
    public GameObject _shield;
    // 캐릭터 정보 참조
    public CCharcterInfo _characterInfo;

    float MaxHp;
    bool GetMineShip = false;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Space")) return;
        
        if (col.tag.Equals("Enemy") || col.tag.Equals("ESLaser") || col.tag.Equals("Boss"))
        {
            // 충돌에 따른 플레이어 쉽 미사일 발사 가능 갯수 줄임
            gameObject.GetComponent<CPlayerShipShot>().count -= 1;
            if(gameObject.GetComponent<CPlayerShipShot>().count <= 0)
            {
                gameObject.GetComponent<CPlayerShipShot>().count = 0;
            }


            float Damage = col.GetComponent<CCharcterInfo>()._damage;
            _characterInfo._hp -= Damage;
            
            //Destroy(col.gameObject);
            _cameraAnimator.Play("CameraShaking");
            _playerAnimator.Play("PlayerHit");
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("MineShip").Length; i++)
            {
                if (GameObject.FindGameObjectsWithTag("MineShip")[i] != null)
                {
                    Destroy(GameObject.FindGameObjectsWithTag("MineShip")[i].gameObject);
                    
                    GetMineShip = false;
                }
                else
                {

                }
            
            }
            
        }
        if (col.tag.Equals("Item"))
        {
            if(col.name.Equals("MineShip(Clone)"))
            {
                if (GetMineShip == false)
                {
                    GetMineShip = true;
                    gameObject.GetComponent<CGetMineShip>().GetMineShip();
                }
                else
                {
                    Debug.Log("[미니 쉽 중복] 아무효과 없음");
                }
                
            }
            if(col.name.Equals("HpUp(Clone)"))
            {

                gameObject.GetComponent<CCharcterInfo>()._hp += 20;
                if(gameObject.GetComponent<CCharcterInfo>()._hp >= MaxHp)
                {
                    gameObject.GetComponent<CCharcterInfo>()._hp = MaxHp;
                }
            }
            if(col.name.Equals("Star(Clone)"))
            {
                int Count = int.Parse(_starCountText.text);
                Count++;
                _starCountText.text = Count.ToString();
            }
            if(col.name.Equals("Shield(Clone)"))
            {
                if(_shield.activeSelf == false)
                {
                    _shield.SetActive(true);
                    Debug.Log("쉴드 시작 : " + _shield.activeSelf.ToString());
                }
                else
                {
                    Debug.Log("[쉴드 중복] 아무효과 없음");
                }
                        
            }
            if(col.name.Equals("PowerUp(Clone)"))
            {
                gameObject.GetComponent<CPlayerShipShot>().count += 1;
                if(gameObject.GetComponent<CPlayerShipShot>().count >= 3)
                {
                    gameObject.GetComponent<CPlayerShipShot>().count = 3;
                }
            }
            
            Destroy(col.gameObject);
        }
    }

	void Start ()
	{
        MaxHp = gameObject.GetComponent<CCharcterInfo>()._hp;

    }
	
}


