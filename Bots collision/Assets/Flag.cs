using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Flag : MonoBehaviour
{
    public int _timeForDrop;
    private int _timer = 0;
    GameObject _winner;

    public UnityEvent OnFlagDrop;

    private void OnTriggerStay(Collider coll)
    {
        //  print($"Enter {coll.name}");
        if (coll.gameObject.GetComponent<HealthComponent>())
        {
            Debug.Log(coll.gameObject.name);
            if (_timer == 0)
            {
                StartCoroutine("DropFlag");
                _winner = coll.gameObject;
            }

        }

    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject == _winner)
        {
            _timer = 0;
            StopAllCoroutines();
        }
    }



    private IEnumerator DropFlag()
    {
        while (_timer < _timeForDrop)
        {
            _timer += 1;
            Debug.Log(_timer);
            if (_timer == _timeForDrop)
            {
                DeleteEnemies();
                OnFlagDrop?.Invoke();

            }

            yield return new WaitForSeconds(1);
        }


    }

    private void DeleteEnemies()
    {
        if (_winner.layer == LayerMask.NameToLayer("PlayerMask"))
        {
            var enemies = GameObject.FindGameObjectsWithTag("BotRed");
            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i]);
            }
        }
    }
}
