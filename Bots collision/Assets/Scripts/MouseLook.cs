using UnityEngine;
using System.Collections;
public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    private Transform _player;
    public RotationAxes axes = RotationAxes.MouseXAndY;
    [SerializeField, Range(0, 50)]
     float sensitivityHor = 9.0f;
    [SerializeField, Range(0, 50)]
     float sensitivityVert = 9.0f;
    [SerializeField, Range(-90, 0)]
     float minimumVert = -45.0f;
    [SerializeField, Range(0, 90)]
     float maximumVert = 45.0f;
    private float _rotationX = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            _player.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
            _player.Rotate(Vector3.up * Input.GetAxis("Mouse X") * sensitivityVert);

        }

    }
}