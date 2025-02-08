using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputType InputType;

    [Header("Shared Joystick Settings")]
    [SerializeField] float joystickSensitivity = 1;

    [Header("Movement Constraints")]
    [Tooltip("Freeze movement on X axis if true.")]
    public bool freezeX;
    [Tooltip("Freeze movement on Z axis if true.")]
    public bool freezeZ;

    [SerializeField] InputType inputType;
    [SerializeField] UIJoystickInput uiJoystickInput;
    [SerializeField] DragInput dragInput;
    [SerializeField] float startSpeed = 5f;
    [SerializeField] float speedIncreasePerSecond = 0.05f;

    float _currentSpeed;

    AxisJoystickInput _axisJoystickInput;
    IPlayerInput _playerInput;
    Vector2 _input;
    Rigidbody _rb;
    bool _isMoving;

    void Start()
    {
        _axisJoystickInput = new AxisJoystickInput(joystickSensitivity);
        uiJoystickInput.JoystickSensitivity = joystickSensitivity;
        _rb = GetComponent<Rigidbody>();
        GameStateManager.OnInGame += OnInGame;
        GameStateManager.OnGameOver += OnGameOver;
    }

    void FixedUpdate()
    {
        if (!_isMoving) return;
        Move();
    }

    void Update()
    {
        if (!_isMoving) return;
        SelectInputType();
        _input = _playerInput.ReadInput();
        _currentSpeed += speedIncreasePerSecond * Time.deltaTime;
    }

    void SelectInputType()
    {
        // in case the input type is changed during gameplay
        _playerInput = inputType switch
        {
            InputType.AxisJoystick => _axisJoystickInput,
            InputType.UIJoystick => uiJoystickInput,
            InputType.Drag => dragInput,
            _ => _playerInput,
        };
        InputType = inputType;
    }

    void Move()
    {
        if (freezeX) _input.x = 0;
        if (freezeZ) _input.y = 0;
        Debug.Log(_input);
        Vector3 newPos = _rb.position
                         + new Vector3(_input.x, 0, _input.y)
                         + Vector3.right * (_currentSpeed * Time.fixedDeltaTime);
        _rb.MovePosition(newPos);
    }

    void OnGameOver()
    {
        _isMoving = false;
        _rb.isKinematic = false;
        _rb.linearVelocity = Vector3.zero;
    }

    void OnInGame()
    {
        _currentSpeed = startSpeed;
        _isMoving = true;
        _rb.isKinematic = true;
    }
}

public enum InputType
{
    AxisJoystick,
    UIJoystick,
    Drag,
}
