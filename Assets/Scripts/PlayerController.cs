using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //-------------------Ref Object-----------------------
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private bool _is3D;

    [SerializeField]
    private OnPlayerSO _onPlayerDeathSO;

    [SerializeField]
    private OnWinningEventSO _onWinningEventSO;

    [SerializeField]
    private GameObject _camera;

    [SerializeField]
    private float _attackTime;
    private InputManager inputManager;

    private CharacterController _controller;
    private Vector3 _direction;

    private Vector3 _dragPosition;

    private Animator _animator;
    private bool _isSitting;

    private Vector3 _rotation;

    private GameObject _rootModel;

    void Start()
    {
        TryGetComponent<Animator>(out _animator);
        _controller = GetComponent<CharacterController>();
        _direction = Vector3.zero;
        FindRoot();
    }

    private void FindRoot()
    {
        int count = gameObject.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            if (gameObject.transform.GetChild(i).name == "root")
            {
                _rootModel = gameObject.transform.GetChild(i).gameObject;
                break;
            }
        }
    }

    private void OnEnable()
    {
        inputManager = InputManager.Instance;

        inputManager.OnDragging += DragAction;

        inputManager.OnAttack += AttackAtion;

        inputManager.OnLooking += LookAction;

        _onWinningEventSO.AddAction(RotateToGame);
        _onPlayerDeathSO.AddAction(Death);
    }

    private void OnDisable()
    {
        inputManager.OnDragging -= DragAction;

        inputManager.OnAttack -= AttackAtion;

        inputManager.OnLooking -= LookAction;

        _onPlayerDeathSO.RemoveAction(Death);

        _onWinningEventSO.RemoveAction(RotateToGame);
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    public void RotateToGame()
    {
        float y = _camera.transform.eulerAngles.y;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, y, transform.eulerAngles.z);
        // Debug.Log("Trigger rotate " + y);
    }

    private void LookAction(Vector2 position)
    {
        if (!_is3D)
            return;
        position = position.normalized;
        _rotation = new Vector3(position.y, position.x, 0);
        // Debug.Log("Head apply " + _rotation);
    }

    public void AttackAtion()
    {
        _animator?.ResetTrigger("Attack");
        _animator?.SetTrigger("Attack");
    }

    private void DragAction(Vector2 position)
    {
        _dragPosition = position;
    }

    // Update is called once per frame
    void Update()
    {
        ApplyMove();
        ApplyRotation();
    }

    private void ApplyRotation()
    {
        Vector3 newEulerAngle = transform.rotation.eulerAngles + _rotation * 2;
        // ScaleRotation(ref newEulerAngle);
        // transform.rotation = Quaternion.RotateTowards(
        //     transform.rotation,
        //     Quaternion.Euler(newEulerAngle),
        //     100 * Time.deltaTime
        // );
        transform.localRotation = Quaternion.Euler(newEulerAngle);
    }

    private void ScaleRotation(ref Vector3 vector3)
    {
        if (vector3.x > 45 && vector3.x < 315)
        {
            vector3.x = _rotation.x < 0 ? 315 : 45;
        }
    }

    private void ApplyMove()
    {
        // Calculate the direction based on the camera's forward and right vectors
        Vector3 forward = _is3D ? transform.forward : Vector3.up;
        forward.y = _is3D ? 0f : forward.y;
        forward.z = _is3D ? forward.z : 0f;
        forward.Normalize(); // Ensure the vector has a length of 1

        Vector3 right = transform.right;
        right.y = 0f; // Ignore the vertical component
        right.Normalize(); // Ensure the vector has a length of 1

        _direction = forward * _dragPosition.y + right * _dragPosition.x;
        ScaleNomal(ref _direction);

        _animator?.SetFloat("Speed", _direction.magnitude);
        if (_direction.magnitude > 0.1f)
        {
            _animator?.ResetTrigger("Attack");
        }

        _controller.Move(speed * Time.deltaTime * _direction);
    }

    private void ScaleNomal(ref Vector3 direction)
    {
        if (direction.magnitude > 1)
        {
            direction /= direction.magnitude;
        }
    }

    public void DoSit(Vector3 chairPosition)
    {
        Debug.Log("DoSit Called");
        transform.localPosition = new Vector3(chairPosition.x, 0, chairPosition.z);
        Physics.SyncTransforms();
        _animator?.SetTrigger("Sit");
        _isSitting = true;
    }

    public void UnSit()
    {
        Debug.Log("DoSit Called");
        // Physics.SyncTransforms();
        _animator?.SetTrigger("UnSit");
        _isSitting = false;
    }

    public bool IsSitting()
    {
        return _isSitting;
    }

    public void MovePosition(Vector3 vector3)
    {
        // Debug.Log("Transform to " + vector3);

        transform.position = vector3;

        Physics.SyncTransforms();

        // if (_rootModel == null)
        //     return;

        // StartCoroutine(Wait(2.5f));
    }

    private IEnumerator Wait(float waitTime)
    {
        _rootModel.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        _rootModel.SetActive(true);
        // yield return new WaitForSeconds(waitTime);
    }

    public void Pause()
    {
        gameObject.SetActive(false);
    }

    public void Resume()
    {
        gameObject.SetActive(true);
    }

    // public void Interact();
}
