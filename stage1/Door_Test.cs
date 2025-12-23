using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door_Test : MonoBehaviour
{
    [Header("Core Reference")]
    public Dialog_Test dialog_; //타이핑 효과 스크립트 참조

    [Header("State")]
    public bool is_Enter=false;
    public bool is_Interactioning = false;

    [Header("Data & UI Container")]
    string[] Renew_Dialogue;
    public bool Select_need = false;

    public GameObject dialog_parent; // 모든 대화 UI
    public GameObject dialog; // 실제 대화창 오브젝트
    public GameObject select_; // 선택지 오브젝트


    /// <summary>
    /// 외부(NPC, 문 등)에서 대사 데이터와 설정값을 넘겨줌
    /// </summary>
    public void Get_Dialogue(bool is_enter, string[] _dialogue, bool _needSelect)
    {
        is_Enter = is_enter;
        Renew_Dialogue = _dialogue;
        Select_need = _needSelect;
        
    }

    /// <summary>
    /// 스페이스바로 대화의 시작과 끝을 관리
    /// </summary>
    public void Interaction()
    {
        //스페이스바를 누르면 interaction 값을 받아줄, update 안에 넣을 함수 필요
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (!is_Interactioning)
            {
                // 대화창 활성화
                dialog.SetActive(true); 
                is_Interactioning = true;
                // 대사를 타이핑 연출로 전달
                dialog_.Typing_trigger(Renew_Dialogue, Select_need);
                

            }
        else
            {
                dialog_.dialogObj.SetActive(false); // 타이핑 스크립트의 오브젝트 비활성화
                is_Interactioning = false;
                
                // 선택지 UI도 비활성화
                select_.SetActive(false); 
            }
        }
    }

    void Start()
    {
        // 최상위 부모를 기준으로 자식들을 탐색하여 참조를 자동화했습니다.
        // 이는 UI 구조가 변경되어도 유연하게 대응하기 위한 설계입니다.
        dialog_parent = GameObject.Find("Dialog");
        dialog = dialog_parent.transform.Find("DialogBase").gameObject;
        dialog_ = dialog.transform.GetComponent<Dialog_Test>();
        select_ = dialog_parent.transform.Find("SelectedBase").gameObject;

        // 시작할때 데이터가 남아있지 않게 하기 위해 초기화
        Renew_Dialogue = null;
        Select_need = false;
    }

    void Update()
    {
        // 문 앞에 서 있을 때나 문 범위 밖인데도 대화창이 켜져 있는 경우에 스페이스바로 끌 수 있게 함
        if (is_Enter || is_Interactioning)
        {
            Interaction();
        }
    }
}
