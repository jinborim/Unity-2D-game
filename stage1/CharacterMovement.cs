using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement: MonoBehaviour
{
    public GameObject character;
    Rigidbody2D playerRd; //rigid body 이름을 playerRd로
    private SpriteRenderer CharacterSprite;

    public Animator Char_ani;

    public float speed = 5.0f;
    public float jumppower = 10f;
    public bool isground = false;//땅에 닿았는가
    public bool doublejumpable;//더블점프 아이템을 먹었는가
    public bool firegun = false;//빨간총 아이템 활성화
    public int JumpCount = 1;
    public int DoubleJumpCount = 2;

    //아래는 총알 방향을 결정하기 위한 bool 변수
    public bool left = false;
    public bool right = true;
    public bool movable = true;

    public bool is_Beat=false;
    public float BeatTime;

    private Door_Test is_door_Enter;

    public SoundEffect_Manager soundEffect;
    

    public StageManager stage;
    public STAGE_Maintain stage_now;
    public string Scene_name;

    //씬마다 로드
    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 체인을 걸어서 이 함수는 매 씬마다 호출된다.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Scene_name = scene.name;
        
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }



    // Start is called before the first frame update
    void Start()
    {
        JumpCount = 1;
        DoubleJumpCount = 2;

        is_Beat = false;
        BeatTime = 1.5f;

        //guninventory = GetComponent<GunInventory>();
        playerRd = character.GetComponent<Rigidbody2D>();
        Char_ani = GetComponent<Animator>();

        //JumpCount = 0;
        is_door_Enter = GameObject.FindObjectOfType<Door_Test>();
        CharacterSprite = transform.GetComponent<SpriteRenderer>();
        stage = GameObject.FindObjectOfType<StageManager>();
        stage_now = GameObject.FindObjectOfType<STAGE_Maintain>();

        soundEffect = GameObject.FindObjectOfType<SoundEffect_Manager>();
        
    }

    private void Awake()
    {
        
        doublejumpable = false;
        character = this.gameObject;
        
        //Debug.Log("캐릭터");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            soundEffect.Effect_Sound("ITEMGET");
            if (collision.gameObject.GetComponent<Potion>() != null)
            {
                Potion_Spawner potion = GameObject.FindObjectOfType<Potion_Spawner>();
                if (potion != null)
                {
                    potion.potionCount -= 1;
                }
            }
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Gun"))
        {
            soundEffect.Effect_Sound("ITEMGET");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("DoubleJump"))
        {
            soundEffect.Effect_Sound("ITEMGET");
            collision.gameObject.SetActive(false);
            doublejumpable = true;
            /*Collision 충돌 처리할 때는 두 객체 모두 컴포넌트에 RigidBody를 가지고 있고,
            IsTrigger 와 Kinematic 속성이 비활성화 상태이고 Collier 컴포넌트를 둘다 가지고 있을때 사용 가능하다.
            Trigger 사용 할 때는 두 객체 모두 Collider가 있어야하고, 둘 중 하나는 IsTrigger 가 체크
            그리고 RigidBody를 가지고 있어야한다
            >> 따라서 OncollisionEnter로 하면 현재 아이템에 isTrigger가 체크 되어있으므로 실행이 안됨...그래서 OnTriggerEnter로 처리해야 isTrigger를 체크하고도 doublejumpable을 바꿀 수 잇음
            */
        }
        /*if (collision.gameObject.CompareTag("Gun"))
        {
            collision.gameObject.SetActive(false);
            
        }*/
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            isground = true;
            if (doublejumpable == false) { JumpCount = 1; }
            else if (doublejumpable == true) { DoubleJumpCount = 2; }
        }
 

            }

    // Update is called once per frame
    void Update()
    {
        if (movable == true)
        {
            if (is_door_Enter != null)
            {
                if ((Inventory.invectoryActivated == false) && (is_door_Enter.is_Interactioning == false))
                {
                    Movement();
                    //인벤토리가 열려있을 때는 움직이지 못하도록

                }
            }
            if (is_door_Enter == null)
            {
                //씬 마다 door가 있을지 없을지 모르기 때문에..없는 경우에만 그냥 자유롭게 움직이도록 만듦(임시방편
                Movement();
            }
        }
        
        
        
        

    }


    void Movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            Char_ani.SetTrigger("RUN");

            right = false;
            left = true;
            
            character.transform.localScale = new Vector3(-1, 1, 1); // 왼쪽 바라보기
            playerRd.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);

        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            Char_ani.SetTrigger("RUN");
            left = false;
            right = true;
            character.transform.localScale = new Vector3(1, 1, 1); // 오른쪽 바라보기
            playerRd.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
        }

        if (isground)
        {
            if (doublejumpable==true)
            {
                if (DoubleJumpCount > 0)
                {
                    if (Input.GetKeyDown(KeyCode.LeftAlt) == true) //GetkeyDown 으로 안하고 그냥 Getkey로만 하면 뗄 때도 JumpCount가 줄어들어서 점프가 안됨
                    {
                        Char_ani.SetTrigger("JUMP");
                        soundEffect.Effect_Sound("JUMP");
                        playerRd.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);
                        DoubleJumpCount--;
                    }
                }
            }
            else
            {
                if (JumpCount > 0)
                {
                    if (Input.GetKeyDown(KeyCode.LeftAlt) == true) //GetkeyDown 으로 안하고 그냥 Getkey로만 하면 뗄 때도 JumpCount가 줄어들어서 점프가 안됨
                    {
                        Char_ani.SetTrigger("JUMP");
                        soundEffect.Effect_Sound("JUMP");
                        playerRd.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);
                        JumpCount--;
                    }
                }
            }
            
        }

        else
        {

        }
    }


    public IEnumerator OnBeatTime()
    {
        soundEffect.Effect_Sound("DAMAGE");
        for (int i = 0; i < BeatTime * 3; ++i)
        {
            if (i % 2 == 0)
                CharacterSprite.color = new Color32(255, 120, 160, 90);
            else
                CharacterSprite.color = new Color32(255, 120, 160, 180);

            yield return new WaitForSeconds(0.3f);
        }

        //Alpha Effect End
        CharacterSprite.color = new Color32(255, 255, 255, 255);

        is_Beat = false;

        yield return null;
    }

    public void DIE()
    {
        stage_now.sceneNow = Scene_name;
        //여기에 씬 전환...
        SceneManager.LoadScene("GameOver");
        //Destroy(gameObject, 0.5f);
    }

}
