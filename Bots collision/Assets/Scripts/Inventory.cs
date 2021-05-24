using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory :MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _myInventory;

    public List<GameObject> CurrentInventory { get => _myInventory; set => _myInventory = value; }

    private void Start()
    {
        _myInventory = new List< GameObject>();
    }
}
