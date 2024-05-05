using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Joystick")]
    [SerializeField] private GameObject joystick;
    void Start()
    {
    }

    void Update()
    {
        SetjoyStickPosition();
    }

    public void SetjoyStickPosition()
    {
        

    }

}
