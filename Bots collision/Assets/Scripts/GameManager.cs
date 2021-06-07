using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public Animator _an;
    BotsUI _bots;
    GameObject _player;
    public Text _winText;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _bots = FindObjectOfType<BotsUI>();
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Update()
    {
        CheckWinner();
    }

    private void CheckWinner()
    {
        if (_bots.BlueWin || _bots.RedWin)
        {
            OpenWinMenu();
        }
    }

    public void OpenWinMenu()
    {
        transform.SetAsFirstSibling();
        _an.SetBool("Open", true);
        //GameObject.FindObjectOfType<Gun>().gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        _winText.text = (_bots.BlueWin) ? $"Blue team Win " : $"Red team Win";
    }


}
