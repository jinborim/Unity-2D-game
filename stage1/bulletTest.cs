using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터에게 할당해서 총알이 캐릭터로부터 나오게끔 했다. 나중에 총으로 옮겨서 적용해보려고 함.

public class bulletTest : MonoBehaviour
{
    GameObject Character;
    GameObject FIREGUN;
    //private GunInventory guninventory;
    
    
    public GameObject bulletPrefab;
    //public string Active_Bullet;
    public GunType_selected gun;

    public SoundEffect_Manager soundEffect;

    public float bulletSpeed = 10.0f;

    private void Start()
    {
        Character = GameObject.Find("Character");
        soundEffect = GameObject.FindObjectOfType<SoundEffect_Manager>();
        //캐릭터라는 이름의 오브젝트로 부터 가져올 것을 저장하는 변수
        
    }

    void bullet_func()
    {
        
        if (Input.GetKeyDown(KeyCode.A) == true)
        {
            if (bulletPrefab != null)
            {
                soundEffect.Effect_Sound("SHOOT");
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

                Rigidbody2D bb = bullet.GetComponent<Rigidbody2D>();


                //총알의 방향 결정
                if (Character.GetComponent<CharacterMovement>().left == true)
                {
                    bb.AddForce(Vector2.left * bulletSpeed, ForceMode2D.Impulse);
                }
                else if (Character.GetComponent<CharacterMovement>().right == true)
                {
                    bb.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                }
            }
            

        }

    }


    


    public void bullet_changer_test(GunType_selected _gun)
    {

        gun = _gun;
        if (gun != null)
        {
            bulletPrefab = gun.BulletPrefab;
        }
        else
        {
            bulletPrefab = null;
        }
    }
   


    void Update()
    {
        bullet_func();
        
    }
}
