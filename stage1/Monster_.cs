using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster_ : MonoBehaviour
{
/**
* 몬스터의 체력을 관리하고 데미지를 입었을때 체력 바 UI 관리
**/
    public float StartHealth; //몬스터의 최대 체력
    public float Health; // 몬스터의 현재 체력
    public MonsterMovement monster_move; // MonsterMovement 스크립트 참조

    public GameObject HealthBar; // 몬스터의 체력 바 UI

    private void Start()
    {
        monster_move = this.GetComponent<MonsterMovement>(); //같은 씬에 있는 MonsterMovement 스크립트를 가져와서 연결
         //MonsterMovement에 있던 체력 기본 체력 값을 가져와 초기 체력 설정
        StartHealth = monster_move.M_health;
        Health = monster_move.M_health;
    }

    //외부(총아르 플레이어)에서 데미지를 입힐때 호출
    public void GetDamage(int damage)
    {
        Health -= damage; //현재 체력에서 받은 데미지 만큼 차감
        HealthBar.GetComponent<Image>().fillAmount = Health / StartHealth; //현재 체력 / 최대 체력 비율 계산하여 Image의 fillAmount에 적용 
    }

}
