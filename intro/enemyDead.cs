using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDead : MonoBehaviour
{
    public GameObject enemy;
    public PlayerMovement player;

    public float delta = 0;
    public float interval = 2.5f;

    //int bulletReach;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        
    }

    

    public void Call0()
    {
        StartCoroutine(player.Scene33(true));
    }

    

}
    /*void OnCollisionEnter(Collision otherObj)
    {
         if (bulletReach == 3)
        {
            Destroy(enemy, .5f);
        } 
    }*/

    /* void OnTriggerEnter2D(Collider2D other)
        //rigidBody가 무언가와 충돌할때 호출되는 함수 입니다.
        //Collider2D other로 부딪힌 객체를 받아옵니다.
    {
        if (other.gameObject.tag.Equals("bullet"))
        //부딪힌 객체의 태그를 비교해서 적인지 판단합니다.
        {
            //해당객체 파괴합니다.
            Destroy(this.gameObject);
        }
    } */
    

