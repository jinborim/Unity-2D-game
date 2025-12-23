using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next_Door : MonoBehaviour
{
/**
* 캐릭터 감지 여부에 따라 대화창을 띄우고 유저가 다음스테이지로 이동할 것인지 선택하게 함
**/
    [Header("NextStage Settings")]
    public string SceneName; // 이동하고자하는 다음 씬 이름

    [Header("Communication")]
    private Door_Test door; // 문과 상호작용하는 Door_Test 참조
    public Select_Yes selected; // Yes를 누를 시 실행될 로직 참조

    [Header("State")]
    public bool is_Enter = false; // 플레이어가 현재 범위 안에 있는지 체크
    public string[] Door_dialogue = new string[2]; // 대화창에 출력될 텍스트 데이터


    void Start()
    {
        //Door_Test 매니저를 찾고, 자식 오브젝트에 있는 선택 로직을 캐싱
        //GetComponentInChildren을 통해 하이어라키 구조를 활용한 참조를 수행
        door = GameObject.FindObjectOfType<Door_Test>();
        selected = door.select_.GetComponentInChildren<Select_Yes>();

        // 초기 대화 내용을 설정 (인스펙터나 외부 데이터에서 수정 가능하도록 함)
        Door_dialogue =new string[] { "다음 스테이지로 이동할까?" };
        
    }

    /// <summary>
    /// 캐릭터가 대화창 감지 범위(Trigger)에 진입했을 때 발생
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //"Character" 태그 충돌만 선별적으로 처리
        if (collision.gameObject.CompareTag("Character") == true)
        {
            is_Enter = true;

            // YES 버튼에 다음 씬 이름을 미리 주입
            selected.GetSceneName(SceneName);
            // 대화창 매니저에게 대사 배열과 출력 여부를 전달하여 UI를 활성화
            door.Get_Dialogue(is_Enter, Door_dialogue, true);
            
        }
    }

    /// </summary>
    /// 캐릭터가 해당 범위를 벗어났을 때 상태를 초기화하고 UI를 닫음
    /// </summary>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Character") == true)
        {
            //Debug.Log("충돌 해제");
            // 대화창을 닫기 위해 null 데이터와 false를 보냄
            // 데이터를 null로 초기화하여 이전 대사가 남지 않도록 관리
            is_Enter = false;
            door.Get_Dialogue(is_Enter, null, false);

        }
    }
}
