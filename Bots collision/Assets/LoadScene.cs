using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    public Text _progressText;
    public Text _Text;

    public Image _progressBar;
    public int _sceneId;
    float _wait = 1f;
    float _stepProgress = 0.9f;
    float progress = 0f;
    AsyncOperation _asyncOperation;
    // Start is called before the first frame update
    void Start()
    {

     //   StartCoroutine(LoadNewScene());
    }

  public  IEnumerator LoadNewScene(int id)
    {
        yield return new WaitForSeconds(_wait);
        _asyncOperation = SceneManager.LoadSceneAsync(_sceneId);
        while (!_asyncOperation.isDone)
        {
            _Text.enabled = true;
            progress = _asyncOperation.progress / _stepProgress;
            _progressBar.fillAmount = progress;
            _progressText.text = ((int)(progress * 100)).ToString();
            yield return 200;
        }

    }

}
