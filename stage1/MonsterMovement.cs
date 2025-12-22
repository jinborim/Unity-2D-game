using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterMovement : MonoBehaviour
{
/**
*몬스터의 AI 이동(지형 감지), 플레이어와의 충돌 시 데미지 처리, 그리고 사망 시 보스 스크립트와의 연동
**/
    Rigidbody2D monsterRd; //물리 이동을 위한 Rigidbody
    public int nextMove; // 다음 이동방향
    public float speed = 2f; //이동 속도
    public int M_health; // 몬스터의 현재 체력

    public bool is_endpoint; // 맨 끝에 도달했는지 체크
    public HP_Manager hp_manger; //플레이어의 체력을 깎기 위한 매니저 참조

    public Monster monster_; // 몬스터 데이터 정보
    public CharacterMovement character; // 플레이어 상태 확인용
    public Boss_Movement Boss; // 보스가 소환한 쫄몹인 경우 보스에게 알림용



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //캐릭터는 기본적으로 isTrigger가 활성화되어있지 않기때문에 이 함수를 사용한다.
        //Character 태그를 가진 오브젝트와 충돌했을때
        if (collision.gameObject.CompareTag("Character"))
        {
            if (character.is_Beat == false)
            {
                if (hp_manger == null)
                {
                    hp_manger = GameObject.FindObjectOfType<HP_Manager>();
                }
                hp_manger.Damaged(monster_.damage);
                //StartCoroutine(character.OnBeatTime());
            }
        }
    }
    //트리거 충돌시
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            if (character.is_Beat == false) //플레이어가 무적 상태가 아닐 때만 데미지 입힘
            {
                if (hp_manger == null) // 매니저를 못찾았으면 다시 찾기
                {
                    hp_manger = GameObject.FindObjectOfType<HP_Manager>();
                }
                hp_manger.Damaged(monster_.damage);
                //캐릭터에게 데미지 전달
            }
        }
        
    }

    //몬스터가 데미지를 입을 때 호출되는 함수
     public void health_manager(int damage)
    {
        this.M_health -= damage; //체력 감소
        if (this.M_health <= 0) //체력이 0 이하면 죽음
        {
            Destroy(gameObject); // 오브젝트 제거
            //보스가 소환한 몬스터라면 남은 몬스터 수를 줄임
            if (Boss != null) 
            {
                Boss.Rest_count -= 1;
            }

        }
    }
   

    private void Start()
    {
        is_endpoint = false;
        //게임 시작 시 필요한 컴포넌트들을 씬에서 찾아 연결
        hp_manger = GameObject.FindObjectOfType<HP_Manager>();
        M_health = monster_.M_health;
        character = GameObject.FindObjectOfType<CharacterMovement>();
        Boss = GameObject.FindObjectOfType<Boss_Movement>();
    }

    private void Awake()
    {
        monsterRd = GetComponent<Rigidbody2D>();
        //Invoke("Think", 5);//초기화 함수 안에 넣어서 실행될 때 마다 nextMove변수가 초기화됨
    }
}
