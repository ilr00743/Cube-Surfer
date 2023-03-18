using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    [SerializeField] private StartPanel _startPanel;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _strafeSpeed;
    private InputActions _inputActions;
    public bool CanMove { get; set; }

    private void Awake()
    {
        _inputActions = new InputActions();
    }

    private void OnEnable()
    {
        _inputActions.Gameplay.Enable();
        _startPanel.Tapped += () => CanMove = true;
    }
    
    private void OnDisable()
    {
        _inputActions.Gameplay.Disable();
    }
    
    private void Update()
    {
        if(CanMove == false) return;
        
        var inputVector = _inputActions.Gameplay.Move.ReadValue<Vector2>();
        Move(inputVector);
    }

    private void Move(Vector3 direction)
    {
        transform.Translate(Vector3.forward * (_forwardSpeed * Time.deltaTime));
    
        var positionX = direction.x * _strafeSpeed;
        var newPosition = transform.position;
        
        newPosition.x += positionX * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, -2,2);
        transform.position = newPosition;
    }
}