using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
/**
* 게임 카메라가 평소에는 플레이어를 따라다니게 함
* 보스전에 진입하면 특정 위치로 고정되게 만드는 카메라 시스템
**/

    public GameObject target; // 카메라가 따라갈 대상
    public GameObject BossTarget; // 보스전 때 기준이 될 대상

    public Vector3 bossTransform; // 보스전 시 고정될 카메라 좌표값

    public float moveSpeed = 3;// 카메라가 따라갈 속도
    private Vector3 targetPosition; // 대상의 현재 위치

    public Boss_Trigger is_boss; //보스전 시작 여부를 알려주는 트리거(발판)

    // Start is called before the first frame update
    void Start()
    {
        //필요한 오브젝트들을 이름이나 타입으로 찾아서 연결
        is_boss = GameObject.FindObjectOfType<Boss_Trigger>();
        BossTarget = GameObject.Find("Boss");
        target = GameObject.Find("Character");

        //보스 대상이 존재한다면 보스전용 카메라 위치 미리 계산
        if (BossTarget != null)
        {    
            //x는 보스위치, Y는 -1로 고정, Z는 현재 카메라의 깊이 유지
            bossTransform.Set(BossTarget.transform.position.x, -1, this.transform.position.z);
        }
        
    }

    //플레이어를 부드럽게 따라가는 함수
    public void Character_movement()
    {
        // this는 카메라를 의미 (z값은 카메라값을 그대로 유지)
        targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

        // vectorA -> B까지 T의 속도로 이동
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        
    }
    //보스전 진입 시 카메라를 보스 구역으로 이동시키는 코루틴
    public IEnumerator Fixed_Boss()
    {
        do
        {
            //보스전 고정 위치로 이동
            this.transform.position = Vector3.Lerp(this.transform.position, bossTransform, moveSpeed * Time.deltaTime);
            //0.01초 대기후 다시 반복
            yield return new WaitForSeconds(0.01f);

            //카메라가 목표 지점에 거의 도달할 때까지 반복
        } while (this.transform.position != bossTransform);
          //루프 종료 후 정확한 위치로 강제 고정  
        this.transform.position=bossTransform;
    }

    public void Update()
    {
    if (target != null)
        {
            // 보스 트리거가 존재하고, 아직 보스전 상태가 아니라면 플레이어를 추적
            if (is_boss != null)
            {
                if (is_boss.Is_bossStage == false)
                {
                    Character_movement();
                }
                // 보스전(Is_bossStage == true)이 되면 여기서 Update 추적을 멈춤
            }
            // 보스 트리거 자체가 없는 맵이라면 항상 플레이어를 추적
            else if (is_boss == null)
            {
                Character_movement();
            }
        }
    }
}  }
}
