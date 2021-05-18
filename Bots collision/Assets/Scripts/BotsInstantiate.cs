using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsInstantiate : MonoBehaviour
{
    public GameObject _prefabBotRed;
    public GameObject _prefabBotBlue;
    public List<Transform> _spawnTransforRed;
    public List<Transform> _spawnTransforBLue;

    void Awake()
    {
        if (_prefabBotBlue == null || _prefabBotRed == null ||
            _spawnTransforBLue == null || _spawnTransforRed == null) return;
        foreach (var item in _spawnTransforRed)
        {
            Instantiate(_prefabBotRed, item.transform.position, Quaternion.identity).transform.SetParent(item);
        }
        foreach (var item in _spawnTransforBLue)
        {
            Instantiate(_prefabBotBlue, item.transform.position, Quaternion.identity).transform.SetParent(item); 


        }
    }


}
