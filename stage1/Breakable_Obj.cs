using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable_Obj : MonoBehaviour
{
/**
* 총알에 맞으면 사운드를 발생 시키고 몬스터를 제거함
**/

    [SerializeField] //변수를 private으로 유지하면서 유니티 인스펙터에서는 할당이 가능하도록함
    GameObject Drop_prefap; //파괴 될 때 생성할 프리팹
    private SpriteRenderer Sprite_; // 오브젝트 이미지를 제어하기 위한 변수
    public SoundEffect_Manager soundEffect; //사운드를 재생할 매니저 스크립트를 참조

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //부딪힌 물체의 태그가 Bullet인지 확인
        if (collision.gameObject.CompareTag("Bullet"))
        {
            soundEffect.Effect_Sound("ITEMBREAK"); //사운드가 ITEMBREAK라는 이름의 효과음을 출력
            GameObject drop_item = Instantiate(Drop_prefap, transform.position, transform.rotation); // 내 위치와 회전값에 맞춰 Drop_prefap을 생성
            Destroy(gameObject); //오브젝트를 지움 몬스터 제거
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Sprite_ = GetComponent<SpriteRenderer>(); //이 오브젝트에 붙여져 있는 SpriteRenderer 컴포넌트를 가져와 연결
        soundEffect = GameObject.FindObjectOfType<SoundEffect_Manager>(); //SoundEffect_Manager 타입을 가진 오브젝트를 찾아 연결
    }

}
