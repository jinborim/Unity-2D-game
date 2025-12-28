using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
/**
 * 1. 지정된 두 지점(endpoint) 사이를 왕복 하는 몬스터의 움직임을 제안
 * 2. 인벤토리 활성화 시 몬스터의 이동을 멈추도록 함
 * 3. Transform.Translate와 eulerAngles를 이용하여 물리 엔진 부하를 최소화하며 이동합니다.
 */
 
    public float speed; //몬스터의 이동 속도

    bool isLeft = true; //현재 이동 방향 상태 (true면 왼쪽, false면 오른쪽)
 
    void Start()
    {
        speed = Random.Range(2, 6); //속도를 2~6사이로 몬스터 마다 움직이는 속도를 다르게 부여함
    }

 
    void Update()
    {
        if (Inventory.invectoryActivated == false) //인벤토리가 닫혀 있을때만 몬스터가 움직이도록 함
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime); 
        }
        
    }
   void TurnAround()
    {
        
            if (isLeft) // 왼쪽으로 간다면
            {
                transform.eulerAngles = new Vector3(0, 180, 0); // Y축 방향을 180도로 반대로 돌려 오른쪽으로 가게함
                isLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0); // 오른쪽으로 가고 있다가 충돌시 다시 왼쪽으로 몸을 돌려 걸어감
                isLeft = true;
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 특정 endpoint와 충돌시 방향 전환
        if(collision.gameObject.CompareTag("endpoint"))
        {
        TurnAround();
    }
}
