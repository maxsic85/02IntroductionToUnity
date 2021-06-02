using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BotsUI : MonoBehaviour
{
    public Text[] _textBlues;
    public Text[] _texteReds;

    [SerializeField]
    List<GameObject> _botsBlue;
    [SerializeField]
    List<GameObject> _botsRed;

    // Start is called before the first frame update
    void Start()
    {
        GetListsBots();
    }

    private void GetListsBots()
    {
        GameObject _player = GameObject.FindGameObjectWithTag("Player");
        _botsBlue = new List<GameObject>();
        var blues = GameObject.FindGameObjectsWithTag("BotBlue");
        foreach (var bot in blues)
        {
            _botsBlue.Add(bot);
        }
        _botsBlue.Add(_player);

        _botsRed = new List<GameObject>();
        var reds = GameObject.FindGameObjectsWithTag("BotRed");
        foreach (var bot in reds)
        {
            _botsRed.Add(bot);
        }
    }
    private void FillTexts(Text[] text, List<GameObject> bots)
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (bots[i] != null) text[i].text = bots[i].gameObject.name +" / "+ bots[i].gameObject.GetComponent<HealthComponent>().Health.ToString()+" hp";
            else text[i].text = "IS DIED";
        }
    }

    // Update is called once per frame
    void Update()
    {
        FillTexts(_textBlues, _botsBlue);
        FillTexts(_texteReds, _botsRed);

    }
}
