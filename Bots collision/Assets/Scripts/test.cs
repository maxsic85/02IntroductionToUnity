using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private List<Target> _currentBots;
    // Start is called before the first frame update
    void Start()
    {
        _currentBots = new List<Target>();
        foreach (var item in GameObject.FindGameObjectsWithTag("Bot"))
        {
            _currentBots.Add(item.GetComponent<Target>());
        }
       
        foreach (Target item2 in _currentBots)
        {
            item2.TakeDamage(50f);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
