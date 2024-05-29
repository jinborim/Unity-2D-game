using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    Potion_Spawner potionSpawner;

    // Start is called before the first frame update
    void Start()
    {
        potionSpawner = GameObject.FindObjectOfType<Potion_Spawner>();
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
