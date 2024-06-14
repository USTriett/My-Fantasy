using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;
    private Vector3 _rotation;

    private InputManager _inputManager;

    // Start is called before the first frame update
    private void Awake()
    {
        _inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        _inputManager.OnLooking += LookAction;
    }

    private void OnDisable()
    {
        _inputManager.OnLooking -= LookAction;
    }

    // Update is called once per frame
    void Update()
    {
        // _controller.enabled = false;
        // _controller.enabled = true;
        ApplyRotation();
    }

    void ApplyRotation()
    {
        // Physics.SyncTransforms();
        // transform.rotation = Quaternion.Slerp(
        //     transform.rotation,
        //     Quaternion.Euler(transform.rotation.eulerAngles + _rotation),
        //     0
        // );
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            Quaternion.Euler(transform.rotation.eulerAngles + _rotation),
            100 * Time.deltaTime
        );

        // Physics.SyncTransforms();
    }

    private void LookAction(Vector2 position)
    {
        position = position.normalized;
        _rotation = new Vector3(position.y, position.x, 0);
        Debug.Log("Head apply " + _rotation);
    }

    private Vector3 ScaleRotation(Vector3 vector3)
    {
        // if (vector3.x > 45 && vector3.x < 315)
        // {
        //     vector3.x = _rotation.x < 0 ? 315 : 45;
        // }
        return vector3;
    }
}
