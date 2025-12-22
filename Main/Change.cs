using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change : MonoBehaviour
{
//메인화면에서 다음 씬으로 넘어가기 위한 코드

    public void SceneChange()
    {
        SceneManager.LoadScene("intro"); //전환할 씬 이름
    }

}
