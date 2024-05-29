using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterMovement : MonoBehaviour
{
    Rigidbody2D monsterRd;
    public int nextMove;
    public float speed = 2f;
    public int M_health;

    public bool is_endpoint;
    public HP_Manager hp_manger;

    public Monster monster_;
    public CharacterMovement character;
    public Boss_Movement Boss;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //캐릭터는 기본적으로 isTrigger가 활성화되어있지 않기때문에 이 함수를 사용한다.
        if (collision.gameObject.CompareTag("Character"))
        {
            if (character.is_Beat == false)
            {
                if (hp_manger == null)
                {
                    hp_manger = GameObject.FindObjectOfType<HP_Manager>();
                }
                hp_manger.Damaged(monster_.damage);
                //StartCoroutine(character.OnBeatTime());

            }
            

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            if (character.is_Beat == false)
            {
                if (hp_manger == null)
                {
                    hp_manger = GameObject.FindObjectOfType<HP_Manager>();
                }
                hp_manger.Damaged(monster_.damage);
                //StartCoroutine(character.OnBeatTime());

            }


        }
        
    }

 
    public void health_manager(int damage)
    {
        this.M_health -= damage;
        if (this.M_health <= 0)
        {
            Destroy(gameObject);
            if (Boss != null)
            {
                Boss.Rest_count -= 1;
            }

        }
    }
   

    private void Start()
    {
        is_endpoint = false;
        hp_manger = GameObject.FindObjectOfType<HP_Manager>();
        M_health = monster_.M_health;
        character = GameObject.FindObjectOfType<CharacterMovement>();
        Boss = GameObject.FindObjectOfType<Boss_Movement>();
    }

    private void Awake()
    {
        monsterRd = GetComponent<Rigidbody2D>();
        //Invoke("Think", 5);//초기화 함수 안에 넣어서 실행될 때 마다 nextMove변수가 초기화됨
    }
    // Start is called before the first frame update

    /*
    void FixedUpdate()
    {
        if (Inventory.invectoryActivated == false)
        {
            //인벤토리가 열려있을 때는 몬스터도 멈추도록
            MonsterMove();
        }
        
    
    }

    void MonsterMove()
    {
        monsterRd.velocity = new Vector2(nextMove, monsterRd.velocity.y);


        //platform check(맵 앞이 낭떨어지면 뒤돌기 위해 지형 탐색)

        //자신의 한 칸 앞 지형 탐색
        Vector2 frontVec = new Vector2(monsterRd.position.x + nextMove * 0.4f, monsterRd.position.y);

        Debug.DrawRay(frontVec, Vector3.down*10, new Color(0, 1, 0));

        RaycastHit2D raycast = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if (raycast.collider == null||is_endpoint==true)
        {
            //Debug.Log("이 앞은 낭떠러지");
            nextMove = nextMove * (-1);//낭떠러지니깐 방향을 반대로 바꿈
            CancelInvoke();//Think를 잠시 멈춘 후 재실행
            Invoke("Think", 5);
        }
    }


    void Think()
    {
        nextMove = Random.Range(-1, 2);
        float time = Random.Range(2f, 5f);
        
        //Think()재귀함수: 딜레이를 쓰지않으면 CPU과부화 되므로 재귀함수를 쓸 때는 항상 주의
        //Think()를 직접 호출하는대신 Invoke()사용
        Invoke("Think", time);//매개변수로 받은 함수를 5초의 딜레이를 부여하여 재실행
    }
    */
}
