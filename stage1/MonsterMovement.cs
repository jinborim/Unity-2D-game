using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterMovement : MonoBehaviour
{
    /* 몬스터 AI 및 상태 관리 시스템 */
    private Rigidbody2D monsterRd;
    public int nextMove; 
    public float speed = 2f;
    public int M_healt;

   public bool is_endpoint; 
    public HP_Manager hp_manger; 

    public Monster monster_; 
    public CharacterMovement character; 
    public Boss_Movement Boss; 

    private void Awake()
    {
        monsterRd = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        is_endpoint = false;
        
        // 시작할 때 미리 찾아두기 (성능 최적화)
        hp_manger = GameObject.FindObjectOfType<HP_Manager>();
        character = GameObject.FindObjectOfType<CharacterMovement>();
        Boss = GameObject.FindObjectOfType<Boss_Movement>();

        if (monster_ != null)
        {
            M_health = monster_.M_health;
        }
    }

    // 캐릭터와 충돌했을 때 (물리)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character") == true)
        {
            if (character.is_Beat == false)
            {
                if (hp_manger != null)
                {
                    hp_manger.Damaged(monster_.damage);
                }
            }
        }
    }

    // 캐릭터와 충돌했을 때 (트리거)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Character") == true)
        {
            if (character.is_Beat == false)
            {
                if (hp_manger != null)
                {
                    hp_manger.Damaged(monster_.damage);
                }
            }
        }
    }

    // 몬스터가 데미지를 입을 때 호출되는 함수
    public void health_manager(int damage)
    {
        this.M_health -= damage;
        
        if (this.M_health <= 0)
        {
            // 사망 처리 전 보스에게 알림
            if (Boss != null) 
            {
                Boss.Rest_count -= 1;
            }
            Destroy(gameObject); 
        }
    }
}
