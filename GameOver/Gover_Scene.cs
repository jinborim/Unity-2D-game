using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gover_Scene : MonoBehaviour
{
/**
* 특정 부모 오브젝트 아래에 있는 모든 자식들을 자동으로 찾아 목록을 만들고, UI관리 구현
**/

    public GameObject Status; //부모 오브젝트
    public GameObject[] Status_child; //자식 오브젝트들을 담아둘 배열
    // Start is called before the first frame update
    void Start()
    {
        //씬 내에서 이름이 "STATUS"인 오브젝트 연결
        Status = GameObject.Find("STATUS");

        //부모가 가진 자식의 개수만큼 배열 크기 서렁
        Status_child = new GameObject[Status.transform.childCount];

        // 반복문을 돌면서 자식 오브젝트들을 하나씩 배열에 저장
        for(int i=0; i < Status.transform.childCount; i++)
        {
            Status_child[i] = Status.transform.GetChild(i).gameObject;
        }
        
    }

    //모든 자식 오브젝트를 비활성화하는 함수
    public void ActiveFalse()
    {
    //배열에 담긴 모든 자식을 하나씩꺼내서
    //SetActive(false)를 통해 화면에서 보이지 않게 비활성화 처리
        for (int i = 0; i < Status_child.Length; i++)
        {
            
            Status_child[i].transform.gameObject.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
