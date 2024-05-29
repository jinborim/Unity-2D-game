using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_base : MonoBehaviour
{
    public static GameObject select_base;

    [SerializeField]
    private GameObject select_base_obj;

    private SelectPanel[] selectPanel_ar;

    // Start is called before the first frame update
    void Start()
    {
        selectPanel_ar = select_base_obj.GetComponentsInChildren<SelectPanel>();
        //this.transform.gameObject.SetActive(false);
    }
    private void Awake()
    {
        select_base = this.gameObject;
    }

}
