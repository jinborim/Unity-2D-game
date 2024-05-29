using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Test : MonoBehaviour
{
    [SerializeField]
    private Inventory theInventory;

    /*[SerializeField]
    private SelectedGunInventory gunInventory;*/

    //private ItemPickUp itempickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item")|| collision.gameObject.CompareTag("Gun"))
        {
            theInventory.AcquireItem(collision.transform.GetComponent<ItemPickUp>().item, collision.transform.GetComponent<ItemPickUp>().gun);
            //gunInventory.AddGunSlot(collision.transform.GetComponent<ItemPickUp>().item, collision.transform.GetComponent<ItemPickUp>().gun);
        }
    }
            

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
