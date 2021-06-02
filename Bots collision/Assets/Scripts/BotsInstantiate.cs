using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsInstantiate : MonoBehaviour
{
    public GameObject _prefabBotRed;
    public GameObject _prefabBotBlue;
    public List<Transform> _spawnTransforRed;
    public List<Transform> _spawnTransforBLue;
    Queue<string> _botnames;

    void Awake()
    {
        _botnames = new Queue<string>();
        string[] _names = { "Mark", "Bob", "Tim", "Eddy", "Bobby", "Fred", "Karl", "Lee", "Bush" };
        for (int i = 0; i < _names.Length; i++)
        {
            _botnames.Enqueue(_names[i]);
        }



        if (_prefabBotBlue == null || _prefabBotRed == null ||
            _spawnTransforBLue == null || _spawnTransforRed == null) return;
        foreach (var item in _spawnTransforRed)
        {
            var a = Instantiate(_prefabBotRed, item.transform.position, Quaternion.identity);
            a.transform.SetParent(item);
            a.name = _botnames.Dequeue();
        }
        foreach (var item in _spawnTransforBLue)
        {
            var b = Instantiate(_prefabBotBlue, item.transform.position, Quaternion.identity);
            b.transform.SetParent(item);
            b.name = _botnames.Dequeue();
        }
    }


}
