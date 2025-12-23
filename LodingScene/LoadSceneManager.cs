using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
/**
* 비 동기 씬 로딩을 시스템을 구현하여 실제 로딩 속도보다 게이지가 자연스럽게 차도록 함
* 시스템이 멈추지 않게 하면서 안전하게 다음 단계로 넘어가도록
**/
    public static string nextScene;
    [SerializeField] Image progressBar;

    private void Start()
    {
        //로딩 씬이 시작되면 바로 실제 씬 코루틴을 실행
        StartCoroutine(LoadScene());
    }

//다음 씬을 설정할때 호출하는 함수
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
    
    IEnumerator LoadScene()
    {
        // 씬 로딩 시작 전 한 프레임 대기
        yield return null;
        // 비동기적으로 씬 로딩을 시작
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        // 씬 로딩이 완료돼도 바로 화면이 넘어가지 않도록 설정
        //이 코드가 없으면 로딩이 끝나자마자 화면이 확 넘어가버림
        op.allowSceneActivation = false;
        
        float timer = 0.0f;
        //로딩이 완료될 때까지 반복
        while (!op.isDone) 
        {
            yield return null;
            timer += Time.deltaTime; // 부드러운 로딩바 연출을 위한 시간

            if (op.progress < 0.9f)
            {
                //실제 로딩 수치만큼 게이지를 부드럽게 채움
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);

                //게이지가 로딩 수치에 도달하면 타이머를 초기화하여 다음 Lerp를 준비
                if (progressBar.fillAmount >= op.progress) {
                    timer = 0f;
                }
            }
        }                else{ //실제 로딩이 90% 완료된 상태
               //Lrep를 사용하면 로딩바가 매끄럽게 이동하는 시각적 효과를 줌
               progressBar.fillAmount = Mathf.Lerp(progressBae.fillAmount, 1f, timer);

                // 게이지가 꽉 찼다면 
               if(progressBar.fillAmount == 0.999f){
                 // 다음 씬으로 넘어감  
               op.allowSceneActivation = true;
               yeid break; //코루틴 종료
           }
           
