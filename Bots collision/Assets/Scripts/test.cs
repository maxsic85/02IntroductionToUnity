using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private List<HealthComponent> _currentBots;
    // Start is called before the first frame update
    void Start()
    {
        _currentBots = new List<HealthComponent>();
        foreach (var item in GameObject.FindGameObjectsWithTag("Bot"))
        {
            _currentBots.Add(item.GetComponent<HealthComponent>());
        }
       
        foreach (HealthComponent item2 in _currentBots)
        {
            item2.TakeDamage(50f);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
