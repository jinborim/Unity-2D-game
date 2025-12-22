using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Gover_Btn : MonoBehaviour, IPointerClickHandler
{
    public STAGE_Maintain stage; //현재 정보를 가지고 있는 클래스 참조

    //마우스로 오브젝트를 클릭했을 때 자동으로 실행되는 함수
    public void OnPointerClick(PointerEventData eventData)
    {
        //클릭한 버튼이 마우스 왼족 버튼이면
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //stage 스크립트에 저장된 현재 가야할 씬 이름으로 이동
            LoadSceneManager.LoadScene(stage.sceneNow);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //STAGE_Maintain 타입의 오브젝트를 찾아 연걸
        stage = GameObject.FindObjectOfType<STAGE_Maintain>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
