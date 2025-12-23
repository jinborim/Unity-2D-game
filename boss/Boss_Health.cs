using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Health : MonoBehaviour
{
/**
* 보스의 체력
**/
    // 보스의 최대 체력화 현재 체력
    public float Full_Health = 150;
    public float Health = 150;

    // 보스의 체력바 부모 오브젝트와 실제 게이지 이미지
    public GameObject boss_health_parent;
    public Image healthBar;

    // 보스의 오브젝트와 움직임 오브젝트 참조
    public GameObject boss;
    public Boss_Movement boss_;


    // Start is called before the first frame update
    void Start()
    {
        // 현재 오브젝트를 부모로 설정
        // 'BossHP'라는 이름의 오브젝트 안의 Image 컴포넌트를 찾아 할당
        // 씬에서 "Boss"라는 이름의 오브젝트와 Boss_Movement 컴포넌트를 찾음
        // 게임 시작 시에는 보스 체력바 UI를 화면에서 숨긴다
        boss_health_parent = this.transform.gameObject;
        healthBar = boss_health_parent.transform.GetChild(0).transform.Find("BossHP").GetComponentInChildren<Image>();
        boss = GameObject.Find("Boss");
        boss_ = GameObject.FindObjectOfType<Boss_Movement>();
        boss_health_parent.transform.GetChild(0).gameObject.SetActive(false);
    }

    //보스가 데미지를 입었을 때 외부에서 호출하는 함수
    public void bossDamaged(int _damage)
    {
        // 보스가 공격받았음을 알림
        boss_.Boss_is_Beat = true;
        if (Health - _damage <= 0)
        {
            Health = 0;
            boss_.BOSSDIE();
            boss_health_parent.gameObject.SetActive(false);
        }
        else if (Health - _damage > 0)
        {
            Health -= _damage;
            if (boss != null)
            {
                StartCoroutine(boss_.BossOnBeatTime());
            }
        }
        healthBar.fillAmount = (Health / Full_Health);
        boss_.RestHealth = Health;
        
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
