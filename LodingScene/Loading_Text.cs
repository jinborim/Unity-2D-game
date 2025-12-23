using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Loading_Text : MonoBehaviour
{
/**
* 다음 스테이지가 용량이 커서 넘어가는 시간 때문에 로딩 씬을 만듦
**/
    public TextMeshProUGUI dialog_context;

    // Start is called before the first frame update
    void Start()
    {
        dialog_context = this.GetComponentInChildren<TextMeshProUGUI>();
        dialog_context.text = ""; //시작할때마다 텍스트를 비움 
        StartCoroutine(Typing("Now Loading...")); // "Now Loding..."이라는 텍스트가 뜸
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Typing(string dialogue)
    {
      while(true){ // 무한 반복
      dialog_context.text = ""; // 반복할 때마다 처음에는 텍스트를 비우면서 시작

        //글자 수 만큼 반복하여 한개씩 출력
      for(int i<0; i<dialog_text.Length; i++){ 
      // i번째 글자를 추가
      dialog_context.text += dialogue[i]

        // 0.15초 정도의 타이핑 속도
      yeid return new WaitForSeconds(0.15f);
    }
        // 완성 된 문장을 1초 정도 보여줌
        yeid return new WaitForSeconds(1.0);
}
