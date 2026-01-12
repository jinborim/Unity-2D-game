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
    public int currentHealth;

    [Header("Referenced Scripts")]
    public HP_Manager hpManager; 
    public Monster monsterData; 
    public CharacterMovement player; 
    public Boss_Movement boss; 

    private void Awake()
    {
        monsterRd = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // 시작 시 캐싱하여 성능 최적화 (Update나 충돌 시 Find 방지)
        if (hpManager == null) hpManager = FindObjectOfType<HP_Manager>();
        if (player == null) player = FindObjectOfType<CharacterMovement>();
        if (boss == null) boss = FindObjectOfType<Boss_Movement>();

        currentHealth = monsterData.M_health;
    }

    // 충돌 처리 로직 통합 관리
    private void OnCollisionEnter2D(Collision2D collision) => HandlePlayerContact(collision.gameObject);
    private void OnTriggerEnter2D(Collider2D collision) => HandlePlayerContact(collision.gameObject);

    private void HandlePlayerContact(GameObject contactObj)
    {
        if (contactObj.CompareTag("Character"))
        {
            // 플레이어가 무적 상태가 아닐 때만 데미지 처리
            if (player != null && !player.is_Beat)
            {
                hpManager?.Damaged(monsterData.damage);
            }
        }
    }

    // 피격 및 사망 처리
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // 보스가 소환한 몬스터라면 보스 스크립트의 카운트 감소
        if (boss != null)
        {
            boss.Rest_count--;
        }
        Destroy(gameObject);
    }
}
