using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMaintain_Test : MonoBehaviour
{
/**
* 씬이 바뀌어도 파괴되지 않고, 게임 내에서 단 하나만 존재해야하는 관리자 오브젝트를 만들 떼 사용
**/
    public static CanvasMaintain_Test Instance; // 다른 스크립트에서 CanvasMaintain_Test로 즉시 접근 할 수 있게 함
    

    //public Color TeamColor;
    private void Awake()
    {
        // 이미 Instance에 등록되어 있다면
        if (Instance != null)
        {
        // 새로 생성된 오브젝를 삭제
            Destroy(gameObject);
            return; //이후 코드 종료
        }
        Instance = this; //Instance가 비어있다면 자신을 위한 인스턴스로 등록
        // 다음 스테이지로 넘어가더라도 이 오브젝트를 삭제하지 않음
        // 캔버스의 데이터나 게임 전체에 유지
        DontDestroyOnLoad(gameObject);
        
    }
}
