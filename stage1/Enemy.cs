using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed; //적의 이동 속도

    bool isLeft = true; //왼쪽을 보고 있는지 확인
 
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2, 6); //속도를 2~6사이로 몬스터 마다 움직이는 속도를 다르게 부여함
    }

    // Update is called once per frame
    void Update()
    {
        if (Inventory.invectoryActivated == false) //인벤토리가 닫혀 있으면 몬스터의 움직임이 멈춤
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime); 
        }
        
    }
   void TurnAround()
    {
        if (collision.gameObject.CompareTag("endpoint")) //부딪힌 투명벽의 태그가 endpoint일 시 - 몬스터가 투명벽 지점에 도달하여 충돌하면 반대쪽으로 움직이게 왕복을 시킨다
        {
            if (isLeft) //왼쪽으로 간다면
            {
                transform.eulerAngles = new Vector3(0, 180, 0); // Y축 방향을 180도로 반대로 돌려 오른쪽으로 가게함
                isLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0); //오른쪽으로 가고 있다가 충돌시 다시 왼쪽으로 몸이 걸엉감
                isLeft = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("endpoint")) TurnAround(); //부딪혔을 때 함수 호출
    }
}
