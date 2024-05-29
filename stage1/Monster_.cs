using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster_ : MonoBehaviour
{
    public float StartHealth;
    public float Health;
    public MonsterMovement monster_move;

    /* public GameObject DamageText;
     public GameObject TextPos; */

    public GameObject HealthBar;
    void Awake()
    {
        
    }

    private void Start()
    {
        monster_move = this.GetComponent<MonsterMovement>();
        StartHealth = monster_move.M_health;
        Health = monster_move.M_health;
    }

    // Start is called before the first frame update
    public void GetDamage(int damage)
    {
        /* GameObject dmgText = Instantiate(DamageText, TextPos.transform.position, Quaternion.identity);
        dmgText.GetComponent<Text>().text = damage.ToString(); */
        Health -= damage;
        HealthBar.GetComponent<Image>().fillAmount = Health / StartHealth;
        /*Destroy(dmgText, 1f);*/
    }

    // Update is called once per frame

}
