using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SetStartPoint : MonoBehaviour
{
    //public string startPoint;
    private GameObject thePlayer;
    public float Xpoint;
    public float Ypoint;
    public Vector2 startpoint;

    // Start is called before the first frame update
    void Start()
    {
        startpoint = new Vector2(Xpoint, Ypoint);
        if (thePlayer == null)
        {
            thePlayer = GameObject.Find("Character");
        }
            
        /*if (startPoint == thePlayer.currentMapName)
        {
            thePlayer.transform.position = transform.position;
        }*/
        thePlayer.transform.position = startpoint;

        if(Dialogue_Maintain.Instance.GetComponentInChildren<Dialog_Test>()&& Dialogue_Maintain.Instance.GetComponentInChildren<Select_base>()!= null)
        {
            Dialogue_Maintain.Instance.GetComponentInChildren<Dialog_Test>().gameObject.SetActive(false);
            Dialogue_Maintain.Instance.GetComponentInChildren<Select_base>().gameObject.SetActive(false);
        }
        

    }
}
