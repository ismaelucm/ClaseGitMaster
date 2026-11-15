using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance
    {
        get { return _instance; }
    }
    private InputControl _theController;

    private InputAction _movement;
    private InputAction _shoot;

    public Vector2 MovementVector { get; private set; }
    public bool Shoot { get; private set; }
    public bool Shooting { get; private set; }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            Init();
        }
    }

    private void Init()
    {
        _theController = new InputControl();
        _theController.Player.Enable();
        _movement = _theController.Player.Move;
        _movement.performed += UpdateMovement;
        _movement.canceled += UpdateMovement;

        _shoot = _theController.Player.Shoot;
        _shoot.performed += UpdateShoot;
        _shoot.canceled += UpdateShoot;
    }

    private void UpdateShoot(InputAction.CallbackContext context)
    {
        Shoot = context.ReadValueAsButton();
        Debug.Log($"{Time.frameCount}: {(Shoot? "Shoot Pressed": "Shoot Released")}");
    }

    private void UpdateMovement(InputAction.CallbackContext context)
    {
        MovementVector = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        Shooting = _shoot.IsPressed();
    }
}
