using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Heart : MonoBehaviour
{
/**
* 유저의 생존과 직결되는 체력(Heart UI)을 제어
**/
    [Header("UI Reference")] //UI 관련 변수
    public GameObject hp_heart;
    public Image hp_Heart;

    [Header("Health Balance")] //수치 설정 변수
    public float filled_amount;
    public int Heart_Health = 100;

    private void Awake()
    {
        // 씬 전환이나 재시작 시 발생할 수 있는 데이터 오류를 방지하기 위해 초기화
        Heart_Health = 100;
    }

    void Start()
    {
        //현재 스크립트가 포함된 게임 오브젝트를 변수에 할당
        hp_heart = this.gameObject;
        // hp_heart 오브젝트에 붙어 있는 Image 컴포넌트를 가져와서 hp_Heart 변수에 저장한다
        hp_Heart = hp_heart.GetComponent<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
