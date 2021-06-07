using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUI : MonoBehaviour
{
    public Text _heathText;

    private GameObject _player;
    private HealthComponent _playerHealth;
    private void Start()
    {
        _player=GameObject.FindGameObjectWithTag("Player");
        _playerHealth = _player.GetComponent<HealthComponent>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
     //   _heathText.text ="Health "+ _playerHealth.Health.ToString();
    }
}
