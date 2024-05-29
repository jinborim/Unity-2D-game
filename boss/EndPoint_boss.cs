using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint_boss : MonoBehaviour
{
    public BoxCollider2D End_collider;
    // Start is called before the first frame update
    void Start()
    {
        End_collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
