using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public static string nextScene;
    [SerializeField] private Image progressBar;

    private void Start()
    {
        // 로딩 씬 시작과 동시에 실제 씬 로딩 코루틴 실행
        StartCoroutine(LoadSceneProcess());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    private IEnumerator LoadSceneProcess()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        
        // 로딩 완료 후 자동 전환 방지 (게이지 연출을 위해)
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime;

            if (op.progress < 0.9f)
            {
                // 실제 로딩 수치(op.progress)까지 부드럽게 보정
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress) timer = 0f;
            }
            else
            {
                // 실제 로딩이 90% 완료된 후, 마지막 100%까지 연출
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);

                if (progressBar.fillAmount >= 1.0f)
                {
                    // 게이지가 다 차면 씬 전환 허용
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
