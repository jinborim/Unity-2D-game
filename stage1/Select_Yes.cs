using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Select_Yes : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("UI Components")]
    private Color color_; // 버튼의 시각적 변화를 줄 Image 컴포넌트
    public Image Panel_Img; 

    [Header("Settings")]
    public string sceneName; // 로드하고자 하는 목적지 씬 이름
    public bool Panel_activated = false; // 현재 버튼의 활성화(마우스 오버) 상태

    
    //외부 시스템 에서 목적지 씬 이름을 전달받는 메서드
    public void GetSceneName(string _sceneName)
    {
        sceneName = _sceneName;
        //Debug.Log(sceneName);
    }

    // 마우스 포인터가 UI 영역에 진입했을 때 호출
    public void OnPointerEnter(PointerEventData eventData)
    {

        Panel_activated = true;
        Panel_ColorChanger(true); 

    }

    // 마우스 포인터가 UI 영역을 벗어났을 때 호출
    public void OnPointerExit(PointerEventData eventData)
    {

        Panel_activated = false; 
        Panel_ColorChanger(false);

    }

    // UI 클릭시 발생하는 이벤트를 처리함
    public void OnPointerClick(PointerEventData eventData)
    {
        // 마우스 왼쪽 버튼을 클릭 여부 및 활성화 상태 확인
        if (eventData.button == PointerEventData.InputButton.Left && Panel_activated)
        {
                // 현재 화면에 표시된 UI 비활성화
                GameObject.Find("DialogBase").SetActive(false);
                GameObject.Find("SelectedBase").SetActive(false);

                // LoadSceneManger를 통한 비동기 또는 커스텀 씬 로딩 실행
                LoadSceneManager.LoadScene(sceneName);

                //데이터 초기화
                sceneName = "";
        }


        //상태값에 따라 버튼의 투명도를 조절함
        public void Panel_ColorChanger(bool isActivated)
        {
            // 기본 색상은 유지하고 투명도만 변경하여 하이라이트 효과 부여
            color_ = Color.white;
            // 참이면 1.0f 거짓이면 0.8f
            // color_a가 아니라 color_.a라고 해야함 변수로 인식할 수도 있음
            color_.a = isActivated ? 1.0f : 0.8f;

            // 색상을 UI 이미지에 반영
            if(Panel_Img != null) // Pane_Img가 있는지 확인
            {
                Panel_Img.color = color_;
            }
        }

        void Start()
        {
            // 컴포넌트 자동 할당을 통한 예외 방지
            if(Panel_Img == null)
            {
                Panel_Img = GetComponent<Image>();
            }
        }

        void Update()
        {
        
        }
    }
