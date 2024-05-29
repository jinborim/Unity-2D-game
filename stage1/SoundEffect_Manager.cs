using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect_Manager : MonoBehaviour
{
    public AudioSource Audio_Source;

    public AudioClip Dialog1_Audio;
    public AudioClip Boss_Dialog;
    public AudioClip Boss_Howl;
    public AudioClip Boss_Die;
    public AudioClip JumpAudio;
    public AudioClip ShootAudio;
    public AudioClip DamageAudio;
    public AudioClip Item_Get_Audio;
    public AudioClip Item_Use_Audio;
    public AudioClip item_Break;

    public static SoundEffect_Manager Instance;


    public void Effect_Sound(string audio_name)
    {
        switch (audio_name)
        {
            case "JUMP":
                //Audio_Source.clip = JumpAudio;
                Audio_Source.PlayOneShot(JumpAudio);
                break;
            case "SHOOT":
                //Audio_Source.clip = ShootAudio;
                Audio_Source.PlayOneShot(ShootAudio);
                break;
            case "DAMAGE":
                //Audio_Source.clip = DamageAudio;
                Audio_Source.PlayOneShot(DamageAudio);
                break;
            case "ITEMUSE":
                //Audio_Source.clip = Item_Use_Audio;
                Audio_Source.PlayOneShot(Item_Use_Audio);
                break;
            case "ITEMGET":
                //Audio_Source.clip = Item_Use_Audio;
                Audio_Source.PlayOneShot(Item_Get_Audio);
                break;
            case "DIALOG1":
                Audio_Source.PlayOneShot(Dialog1_Audio);
                break;
            case "BOSSDIALOG":
                Audio_Source.PlayOneShot(Boss_Dialog);
                break;
            case "BOSSHOWL":
                Audio_Source.PlayOneShot(Boss_Howl);
                break;
            case "ITEMBREAK":
                Audio_Source.PlayOneShot(item_Break);
                break;
            case "BOSSDIE":
                Audio_Source.PlayOneShot(Boss_Die);
                break;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Audio_Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    
    }
}
