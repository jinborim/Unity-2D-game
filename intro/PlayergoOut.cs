using System.Collections;
using UnityEngine;
using UnityEngine.UI; // UI 관련 스크립트에 활용
using UnityEngine.SceneManagement;
public class PlayergoOut : MonoBehaviour
{
    public GameObject player;
    public GameObject npc;
    private Vector3 target;

    public TalkText tt;
    public GameManager manager;

    public npcChange nC;

    /*public SpriteRenderer Img_Renderer;
    public Sprite r_bande;*/


    // Start is called before the first frame update
    void Start()
    {
        
        target.Set(750, 88, transform.position.z);
        //target.Set(750, 88, npctransform.position.z);

        manager = GameObject.FindObjectOfType<GameManager>();

        nC = GameObject.FindObjectOfType<npcChange>();
        

        /* SpriteRenderer spriteR = gameObject.GetComponent<SpriteRenderer>();
         Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/r_bande");
         spriteR.sprite = sprites[0]; */

        /* SpriteRenderer Img_Renderer = gameObject.GetComponent<SpriteRenderer>();

        Img_Renderer.sprite = r_bande;*/

    }

    // Update is called once per frame
    void Update()
    {
        if (tt != null && tt.clickCount == 7)
        {
            /* if (!(manager.panel = false))
            {
                return;
            } */
        StartCoroutine(Scene66(true));
        }
    }
    public IEnumerator Scene66(bool scene6)
    {
        //player.transform.position = Vector3.MoveTowards(player.transform.position, target, 3f);
        //npc.transform.position = Vector3.MoveTowards(npc.transform.position, target, 3f);
        nC.ChangeImage();
        do
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, target, 0.1f);
            npc.transform.position = Vector3.MoveTowards(npc.transform.position, target, 0.1f);
            yield return new WaitForSeconds(0.01f);

        } while ((player.transform.position != target));
        player.transform.position = target;
        npc.transform.position = target;

        //yield return new WaitForSeconds(0.01f);
        //SceneManager.LoadScene("stage1");
        LoadSceneManager.LoadScene("stage1");

    }
}
