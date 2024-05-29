using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public npcMovement npc; 
    private Vector3 target;
    public Animator ani;




    // Vector2 target = new Vector2(250, 88);

    void Start()
    {
        npc = GameObject.FindObjectOfType<npcMovement>();
        target.Set(250, 88, this.transform.position.z);
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    /* public void scene33(bool scene3)
    {
        if (scene3 == true)
        {
            
        }
        
        
    }*/

    public IEnumerator Scene33(bool scene3)
    {
        
        do
        {
            ani.SetTrigger("walkTest");
            transform.position = Vector3.MoveTowards(transform.position, target, 1.2f);
            yield return new WaitForSeconds(0.01f);

        } while (this.transform.position != target);

        this.transform.position = target;

        Call1();


    }

    public void Call1()
    {
      
        StartCoroutine(npc.Scene44(true));
    }
    //Graphic & Input Updates	


}
