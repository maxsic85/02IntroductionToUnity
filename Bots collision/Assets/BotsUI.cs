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
    private bool r, b;

    public bool RedWin
    {
        
        set { r= value; }
        get { return r; }
    }

    public bool BlueWin
    {
        set { b = value; }
        get { return b; }
    }
  

    // Start is called before the first frame update
    void Awake()
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
            if (bots[i] != null) text[i].text = bots[i].gameObject.name + " / " + bots[i].gameObject.GetComponent<HealthComponent>().Health.ToString() + " hp";
            else text[i].text = "IS DIED";


            //  allDead = (bots[i] != null) ? false : true;
          
        }
    }

    private void CheckWin(List<GameObject> bots, out bool allDead)
    {
        allDead = false;
        for (int i = 0; i < bots.Count; i++)
        {
            if (bots[i] != null)
            {
                allDead = false;
                return;
            }
            else
            {
                allDead = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        FillTexts(_textBlues, _botsBlue);
        FillTexts(_texteReds, _botsRed);
        CheckWin(_botsBlue, out r);
        CheckWin(_botsRed, out b);

    }
}
