using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Menu : MonoBehaviour
{
    public QualityLevel _qual;
    public Slider _slider;
    LoadScene _manager;
    public Animator _anim;
    public
    // Start is called before the first frame update
    void Awake()
    {
        _manager = FindObjectOfType<LoadScene>();
        _slider.minValue = 0;
        _slider.maxValue = 100;

    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = _slider.value;
    }

    public void Setting()
    {
        bool a = _anim.GetBool("ShowMenu");
        _anim.SetBool("ShowMenu", !a);
    }

    public void StartGame(int id)
    {
        StartCoroutine(_manager.LoadNewScene(id));
    }
    public void Qiut()
    {
        Application.Quit();
    }

    public void SetQuality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }
}
