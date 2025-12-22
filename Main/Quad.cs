using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour
{

/**
* 게임 메인화면 배경 무한 스크롤 효과
**/

    private MeshRenderer render; // 물체의 겉면 정보를 가져오기 위한 변수

    public float speed; // 배경이 움직이는 속도
    private float offset; // 텍스처 위치를 계산해서 저장할 변수
    // Start is called before the first frame update
 
    void Start()
    { 
        render = GetComponent<MeshRenderer>(); //이 스크립트를 넣은 오브젝트에 MeshRenderer를 찾아 연결
    }

    void Update()
    {
        offset += Time.deltaTime * speed; //시간에 속도를 곱해 부드럽게 움직이도록 함
        render.material.mainTextureOffset = new Vector2(offset, 0); //새로운 Vector2를 생성하여 X축 방향으로만 offset만큼 밀어냄 
    }
}
